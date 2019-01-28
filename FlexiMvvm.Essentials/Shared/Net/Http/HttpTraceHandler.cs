// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlexiMvvm.Diagnostics;
using JetBrains.Annotations;

namespace FlexiMvvm.Net.Http
{
    public class HttpTraceHandler : DelegatingHandler
    {
        private bool _isDebug;
        [CanBeNull]
        private ILogger _logger;

        public HttpTraceHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            SetDebugMode();
        }

        [NotNull]
        private ILogger Logger => _logger ?? (_logger = new ConsoleLogger());

        [NotNull]
        [ItemNotNull]
        protected override async Task<HttpResponseMessage> SendAsync([NotNull] HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Guid requestResponseGuid = Guid.Empty;

            if (_isDebug)
            {
                requestResponseGuid = Guid.NewGuid();
                await LogAsync(requestResponseGuid, request);
            }

            var response = await base.SendAsync(request, cancellationToken).NotNull().ConfigureAwait(false);

            if (_isDebug)
            {
                await LogAsync(requestResponseGuid, response);
            }

            return response;
        }

        [NotNull]
        private async Task LogAsync(Guid requestId, [NotNull] HttpRequestMessage request)
        {
            var requestStringBuilder = new StringBuilder();
            requestStringBuilder.AppendLine($"=============================== REST Request begin ({requestId}) ===============================");
            requestStringBuilder.AppendLine($"{request.Method} {request.RequestUri} HTTP/{request.Version}");
            requestStringBuilder.Append(request.Content?.Headers);
            requestStringBuilder.Append(request.Headers);

            if (request.Content != null)
            {
                requestStringBuilder.AppendLine();
                requestStringBuilder.AppendLine(await request.Content.ReadAsStringAsync());
            }

            requestStringBuilder.AppendLine($"================================ REST Request end ({requestId}) ================================");

            Logger.Log(requestStringBuilder.ToString());
        }

        [NotNull]
        private async Task LogAsync(Guid responseId, [NotNull] HttpResponseMessage response)
        {
            var reasonPhrase = string.Compare(response.StatusCode.ToString(), response.ReasonPhrase, StringComparison.OrdinalIgnoreCase) == 0
                ? string.Empty
                : response.ReasonPhrase;

            var responseStringBuilder = new StringBuilder();
            responseStringBuilder.AppendLine($"============================= REST Response begin ({responseId}) =============================");
            responseStringBuilder.AppendLine($"HTTP/{response.Version} {(int)response.StatusCode} {response.StatusCode} {reasonPhrase}");
            responseStringBuilder.Append(response.Content?.Headers);
            responseStringBuilder.Append(response.Headers);

            if (response.Content != null)
            {
                responseStringBuilder.AppendLine();
                responseStringBuilder.AppendLine(await response.Content.ReadAsStringAsync());
            }

            responseStringBuilder.AppendLine($"============================== REST Response end ({responseId}) ==============================");

            Logger.Log(responseStringBuilder.ToString());
        }

        [Conditional("DEBUG")]
        private void SetDebugMode()
        {
            _isDebug = true;
        }
    }
}
