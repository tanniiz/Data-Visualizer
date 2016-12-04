using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DataVisualizer.UI.Framework
{
    public abstract class ScreenControl<TScreen> : Conductor<TScreen> where TScreen : class
    {
        public Guid ScreenId { get; private set; }
        public bool IsActivated { get; private set; }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            this.Configuration();
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.IsActivated = true;
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.IsActivated = false;
        }

        protected virtual void Configuration() 
        {
            this.ScreenId = new Guid();
        }
    }
}
