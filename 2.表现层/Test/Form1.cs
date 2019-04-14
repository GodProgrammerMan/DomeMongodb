﻿using MongoDB.Molde;
using MongoService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //添加新闻List
            NewService service = new NewService();

            New model = new New() {
                Author = "梁",
                Content = "　新华社北京4月12日电 4月12日，国家主席习近平致电朝鲜最高领导人金正恩，祝贺他再次被推举为朝鲜国务委员会委员长。习近平表示，你在朝鲜最高人民会议第十四届一次会议上再次被推举为朝鲜民主主义人民共和国国务委员会委员长，这体现了朝鲜党和人民对你的信任和拥护。我谨向你致以热烈的祝贺和诚挚的祝愿。我们高兴地看到，近年来，在委员长同志领导下，朝鲜经济社会发展不断取得新成果，社会主义事业进入新的历史阶段。我相信，在委员长同志确定的新战略路线指引下，朝鲜人民一定会在国家建设与发展的各项事业中取得新的更大成就。习近平指出，中朝两国是山水相连的友好邻邦。我高度重视中朝传统友好合作关系。去年以来，我同委员长同志四次会晤，达成一系列重要共识，共同掀开了中朝关系新的篇章。我愿同委员长同志一道，以两国建交70周年为契机，推动中朝关系进一步向前发展，更好造福两国和两国人民。",
                Logo = "http://upload.mnw.cn/2019/0413/thumb_120_80_1555122476575.jpg",
                ReleaseDate = DateTime.Now,
                View = 1,
                Title = "习近平电贺金正恩再次就任朝鲜国务委员会委员长",   
                Source = "新华网 ",
                NewType = ""
            };

            service.InsetrNew(model);
        }
    }
}
