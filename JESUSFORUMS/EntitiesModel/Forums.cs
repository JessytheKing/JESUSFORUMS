﻿using System;
using System.Collections.Generic;


namespace JESUSFORUMS.EntitiesModel
{
    public class Forums
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}