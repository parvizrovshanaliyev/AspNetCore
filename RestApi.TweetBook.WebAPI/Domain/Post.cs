﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RestApi.TweetBook.WebAPI.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
