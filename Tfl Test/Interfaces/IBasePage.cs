using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Tfl_Test.Interfaces
{
    public interface IBasePage
    {
        void NavigateToUrl();
        void CookieOverlay();
    }
}
