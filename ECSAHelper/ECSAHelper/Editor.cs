using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ECSAHelper
{
    public class Editor : IServiceProvider, ITypeDescriptorContext, IWindowsFormsEditorService
    {
        private Editor()
        {
        }

        public IContainer Container { get; private set; }

        public object Instance { get; private set; }

        public PropertyDescriptor PropertyDescriptor { get; private set; }

        public static object Edit(IContainer container, object instance, string propertyName, Type editorBaseType)
        {
            var propertyDescriptor = TypeDescriptor.GetProperties(instance).Find(propertyName, false);

            if (propertyDescriptor == null)
            {
                throw new ArgumentException("Missing property.");
            }

            var editor = new Editor();

            var UIeditor = (UITypeEditor)propertyDescriptor.GetEditor(editorBaseType);

            editor.Instance = instance;
            editor.PropertyDescriptor = propertyDescriptor;
            editor.Container = container;

            return UIeditor.EditValue(editor, editor, propertyDescriptor.GetValue(instance));
        }

        public static object Edit(object instance, string propertyName)
        {
            return Edit(default(IContainer), instance, propertyName, typeof(UITypeEditor));
        }

        public void CloseDropDown()
        {
        }

        public void DropDownControl(Control control)
        {
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IWindowsFormsEditorService))
            {
                return this;
            }

            var serviceProvider = this.Instance as IServiceProvider;
            if (serviceProvider != null)
            {
                var service = serviceProvider.GetService(serviceType);
                if (service != null)
                {
                    return service;
                }
            }

            serviceProvider = this.Container as IServiceProvider;
            if (serviceProvider != null)
            {
                var service = serviceProvider.GetService(serviceType);
                if (service != null)
                {
                    return service;
                }
            }

            return null;
        }

        public void OnComponentChanged()
        {
        }

        public bool OnComponentChanging()
        {
            return true;
        }

        public DialogResult ShowDialog(Form dialog)
        {
            return dialog.ShowDialog();
        }
    }
}