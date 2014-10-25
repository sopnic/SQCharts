﻿// Licensed under the Apache License, Version 2.0. 
// Copyright (c) Alex Lee. All rights reserved.

using SmartQuant.FinChart;
using System;
using System.ComponentModel;

#if XWT
using Xwt;
using Xwt.Drawing;
using Compatibility.Xwt;
#elif GTK
using Gdk;
using Color = Pango.Color;
using Compatibility.Gtk;
#else
using System.Drawing;
using System.Drawing.Drawing2D;
#endif

namespace SmartQuant.FinChart.Objects
{
    public class PathView : IChartDrawable, IZoomable
    {
        private DrawingPath path;

        protected bool toolTipEnabled = true;
        protected string toolTipFormat = "";
        protected DateTime firstDate;
        protected DateTime lastDate;
        protected bool selected;
        protected DateTime chartFirstDate;
        protected DateTime chartLastDate;

        public Pad Pad { get; set; }

        [Description("Enable or disable tooltip appearance for this marker.")]
        [Category("ToolTip")]
        public bool ToolTipEnabled
        {
            get
            {
                return this.toolTipEnabled;
            }
            set
            {
                this.toolTipEnabled = value;
            }
        }

        [Category("ToolTip")]
        [Description("Tooltip format string. {1} - X coordinate, {2} - Y coordinte.")]
        public string ToolTipFormat
        {
            get
            {
                return this.toolTipFormat;
            }
            set
            {
                this.toolTipFormat = value;
            }
        }

        public PathView(DrawingPath path, Pad pad)
        {
            this.path = path;
            this.Pad = pad;
            this.toolTipEnabled = true;
            this.toolTipFormat = "{0} {1} {2} - {3:F6}";
        }

        public void Paint()
        {
            if (this.path.Points.Count < 2)
                return;

            GraphicsPath gPath = new GraphicsPath();
            var point = this.path.Points[0];
            int x1 = Pad.ClientX(point.X);
            int y1 = Pad.ClientY(point.Y);
            for (int i = 1; i < this.path.Points.Count; ++i)
            {
                point = this.path.Points[i];
                int x2 = this.Pad.ClientX(point.X);
                int y2 = this.Pad.ClientY(point.Y);
                gPath.AddLine(new Point(x1, y1), new Point(x2, y2));
                x1 = x2;
                y1 = y2;
            }
            Pad.Graphics.DrawPath(new Pen(this.path.Color, this.path.Width), gPath);
        }

        public void SetInterval(DateTime minDate, DateTime maxDate)
        {
            this.firstDate = minDate;
            this.lastDate = maxDate;
        }

        public Distance Distance(int x, double y)
        {
            return null;
        }

        public void Select()
        {
        }

        public void UnSelect()
        {
        }

        public PadRange GetPadRangeY(Pad pad)
        {
            return new PadRange(0, 0);
        }
    }
}
