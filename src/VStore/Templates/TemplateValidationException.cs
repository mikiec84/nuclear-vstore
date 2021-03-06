﻿using System;

using Newtonsoft.Json.Linq;

using NuClear.VStore.Json;

namespace NuClear.VStore.Templates
{
    public sealed class TemplateValidationException : Exception
    {
        public TemplateValidationException(int templateCode, TemplateElementValidationError error)
        {
            TemplateCode = templateCode;
            Error = error;
        }

        public int TemplateCode { get; }

        public TemplateElementValidationError Error { get; }

        public JToken SerializeToJsonV10()
        {
            var error = Error.ToString();
            return new JObject
                {
                    [Tokens.TemplateCodeToken] = TemplateCode,
                    [Tokens.ErrorToken] = char.ToLower(error[0]).ToString() + error.Substring(1)
                };
        }

        public JToken SerializeToJson()
        {
            var error = Error.ToString();
            return new JObject
                {
                    [Tokens.TemplateCodeToken] = TemplateCode,
                    [Tokens.ErrorsToken] = new JArray
                        {
                            new JObject
                                {
                                    [Tokens.TypeToken] = char.ToLower(error[0]).ToString() + error.Substring(1),
                                    [Tokens.ValueToken] = true
                                }
                        }
                };
        }
    }
}
