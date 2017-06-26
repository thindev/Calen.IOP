using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class JobPositonLevelVM
    {
        string _id;
        string _name;
        string _code;
        string _description;

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Code { get => _code; set => _code = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
