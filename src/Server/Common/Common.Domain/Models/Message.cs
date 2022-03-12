namespace BettingSystem.Domain.Common.Models;

using System;
using Newtonsoft.Json;

public class Message
{
    private string serializedData = default!;

    public Message(object data) 
        => this.Data = data;

    private Message()
    {
    }

    public int Id { get; private set; }

    public Type Type { get; private set; } = default!;

    public bool Published { get; private set; }

    public void MarkAsPublished() => this.Published = true;

    public object Data
    {
        get => JsonConvert.DeserializeObject(
            this.serializedData,
            this.Type,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

        set
        {
            this.Type = value.GetType();
            this.serializedData = JsonConvert.SerializeObject(
                value,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
}