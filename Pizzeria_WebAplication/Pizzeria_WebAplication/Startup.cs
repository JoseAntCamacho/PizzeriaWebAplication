﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Pizzeria_WebAplication.Models;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(Pizzeria_WebAplication.Startup))]

namespace Pizzeria_WebAplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
