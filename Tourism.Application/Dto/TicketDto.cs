﻿using Microsoft.AspNetCore.Http;

namespace Tourism.Application.Dto
{
    public class TicketDto
    {
        public string Title { get; set; }

        public string Description { get; set; }



        public IFormFile Photo { get; set; }


    }
}
