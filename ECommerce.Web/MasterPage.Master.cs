using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce.Web {
    public partial class MasterPage : System.Web.UI.MasterPage {
        public string index { get; set; }
        public string ser { get; set; }
        public string imp { get; set; }
        public string org { get; set; }
        public string abo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}