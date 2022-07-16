
using CsMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CsMvcApp.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class PanelController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Name = "Cengizhan Şirin";

            ViewBag.Mail = "sirin.cengizhan@outlook.com";

            List<Message> messages = new List<Message>();
            messages.Add(new Message() { Content = "23.01.2022 Tarihinde Şirketimiz 1 Gün Boyunca Kapalıdır.", Date = Convert.ToDateTime("22.01.2022"), MessageBuyers = "sirin.cengizhan@outlook.com", MessageSender = "cengizhan@hotmail.com", Subject = "Tatil Hk." });
            messages.Add(new Message() { Content = "Sistemdeki eğitimlerini lütfen tamamlayınız.", Date = Convert.ToDateTime("02.02.2022"), MessageBuyers = "sirin.cengizhan@outlook.com", MessageSender = "mert@hotmail.com", Subject = "Eğitimler Hk." });
            messages.Add(new Message() { Content = "Doğum Gününüz Kutlu olsun.", Date = DateTime.Now, MessageBuyers = "sirin.cengizhan@outlook.com", MessageSender = "uğur@hotmail.com", Subject = "Doğum Günü Hk." });
            return View(messages);
        }
    }

}
