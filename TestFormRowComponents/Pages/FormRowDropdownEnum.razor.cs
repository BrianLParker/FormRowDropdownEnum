using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace TestFormRowComponents.Pages
{
    public partial class FormRowDropdownEnum<TEnum>
    {
        private TEnum _value;
        [Parameter] public string PropertyName { get; set; }
        [Parameter] public string Caption { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter]
        public TEnum Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value)) return;
                _value = value;
                if (ValueChanged.HasDelegate)
                {
                    ValueChanged.InvokeAsync(Value);
                }
            }
        }
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }
        [Parameter] public RenderFragment<TEnum> ChildContent { get; set; }
        [Parameter] public EventCallback<TEnum> ValueChanged { get; set; }
        IEnumerable<TEnum> EnumValues => Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        protected override void OnInitialized()
        {
            if (Value is not Enum) throw new ArgumentException("Value must be of type Enum");
        }
    }
}