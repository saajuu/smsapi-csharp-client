﻿using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class HLRCheckNumber : Base<SMSApi.Api.Response.CheckNumber>
    {
        public HLRCheckNumber() : base() { }

        protected override string Uri() { return "hlrsync.do"; }

        protected string[] numbers;

        public HLRCheckNumber SetNumber(string number)
        {
            this.numbers = new string[] { number };
            return this;
        }

/*
        public HLRCheckNumber SetNumber(string[] numbers)
        {
            this.numbers = numbers;
            return this;
        }
*/

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("number", string.Join(",", numbers));

            return collection;
        }
    }   
}
