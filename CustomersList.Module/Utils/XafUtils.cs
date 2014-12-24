﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace CustomersList.Module.Utils
{
    public static class XafUtils
    {
        public static void RemoveFirstLookupElement(ASPxLookupPropertyEditor lookupPropertyEditor)
        {
            if (lookupPropertyEditor != null)
            {
                lookupPropertyEditor.ControlCreated += (sender, args) =>
                    {
                        var editor = (ASPxLookupPropertyEditor) sender;
                        if (editor.Editor != null && editor.Editor.Controls.Count > 0)
                        {
                            var ddeEditor = editor.Editor.Controls[0] as ASPxLookupDropDownEdit;
                            if (ddeEditor != null)
                            {
                                ddeEditor.PreRender += (o, eventArgs) =>
                                    {
                                        var dd = ddeEditor.DropDown;
                                        if (dd != null && dd.Items != null && dd.Items.Count > 0)
                                        {
                                            dd.Items.RemoveAt(0);
                                        }
                                    };
                            }
                        }

                    };
            }
        }
    }
}
