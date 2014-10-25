﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

#if XWT
using Xwt.Drawing;
#elif GTK
using Gtk;
using Gdk;
using Compatibility.Gtk;
#else
using Compatibility.WinForm;
using System.Drawing;
#endif

namespace SmartQuant.Charting.Draw3D
{
    public class TSurface
    {
        public TColor Diffuse = new TColor(Colors.White);
        public TColor GridDiffuse = new TColor(Colors.Orange);
        public TColor Specular = new TColor(Colors.White);
    }
}
