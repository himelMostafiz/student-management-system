﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITestService
    {
        Task InsertData();
        Task DummyData();
        Task DummyData1();
    }
}
