/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/
// This File has been auto-generated by SWIG and then modified using DALi Ruby Scripts
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.9
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.UIComponents
{

    /// <summary>
    /// A PushButton changes its appearance when is pressed and returns to its original when is released.
    /// </summary>
    public class PushButton : Button
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PushButton(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PushButton_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PushButton obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// To make PushButton instance be disposed.
        /// </summary>
        public override void Dispose()
        {
            if (!Window.IsInstalled())
            {
                DisposeQueue.Instance.Add(this);
                return;
            }

            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicPINVOKE.delete_PushButton(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
                base.Dispose();
            }
        }


        internal class Property : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            protected bool swigCMemOwn;

            internal Property(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            ~Property()
            {
                DisposeQueue.Instance.Add(this);
            }

            public virtual void Dispose()
            {
                if (!Window.IsInstalled()) {
                    DisposeQueue.Instance.Add(this);
                    return;
                }

                lock (this)
                {
                    if (swigCPtr.Handle != global::System.IntPtr.Zero)
                    {
                        if (swigCMemOwn)
                        {
                            swigCMemOwn = false;
                            NDalicPINVOKE.delete_PushButton_Property(swigCPtr);
                        }
                        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                    }
                    global::System.GC.SuppressFinalize(this);
                }
            }

            internal Property() : this(NDalicPINVOKE.new_PushButton_Property(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal static readonly int UNSELECTED_ICON = NDalicPINVOKE.PushButton_Property_UNSELECTED_ICON_get();
            internal static readonly int SELECTED_ICON = NDalicPINVOKE.PushButton_Property_SELECTED_ICON_get();
            internal static readonly int ICON_ALIGNMENT = NDalicPINVOKE.PushButton_Property_ICON_ALIGNMENT_get();
            internal static readonly int LABEL_PADDING = NDalicPINVOKE.PushButton_Property_LABEL_PADDING_get();
            internal static readonly int ICON_PADDING = NDalicPINVOKE.PushButton_Property_ICON_PADDING_get();

        }

        /// <summary>
        /// Creates the PushButton.
        /// </summary>
        public PushButton() : this(NDalicPINVOKE.PushButton_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal PushButton(PushButton pushButton) : this(NDalicPINVOKE.new_PushButton__SWIG_1(PushButton.getCPtr(pushButton)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PushButton Assign(PushButton pushButton)
        {
            PushButton ret = new PushButton(NDalicPINVOKE.PushButton_Assign(swigCPtr, PushButton.getCPtr(pushButton)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Downcasts a handle to PushButton handle.<br>
        /// If handle points to a PushButton, the downcast produces valid handle.<br>
        /// If not the returned handle is left uninitialized.<br>
        /// </summary>
        /// <param name="handle">Handle to an object</param>
        /// <returns>handle to a PushButton or an uninitialized handle</returns>
        public new static PushButton DownCast(BaseHandle handle)
        {
            PushButton ret = new PushButton(NDalicPINVOKE.PushButton_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal new void SetButtonImage(Image image)
        {
            NDalicPINVOKE.PushButton_SetButtonImage__SWIG_0_0(swigCPtr, Image.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetButtonImage(View image)
        {
            NDalicPINVOKE.PushButton_SetButtonImage__SWIG_1(swigCPtr, View.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetBackgroundImage(View image)
        {
            NDalicPINVOKE.PushButton_SetBackgroundImage(swigCPtr, View.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal new void SetSelectedImage(Image image)
        {
            NDalicPINVOKE.PushButton_SetSelectedImage__SWIG_0_0(swigCPtr, Image.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSelectedImage(View image)
        {
            NDalicPINVOKE.PushButton_SetSelectedImage__SWIG_1(swigCPtr, View.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSelectedBackgroundImage(View image)
        {
            NDalicPINVOKE.PushButton_SetSelectedBackgroundImage(swigCPtr, View.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetDisabledBackgroundImage(View image)
        {
            NDalicPINVOKE.PushButton_SetDisabledBackgroundImage(swigCPtr, View.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetDisabledImage(View image)
        {
            NDalicPINVOKE.PushButton_SetDisabledImage(swigCPtr, View.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetDisabledSelectedImage(View image)
        {
            NDalicPINVOKE.PushButton_SetDisabledSelectedImage(swigCPtr, View.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal enum PropertyRange
        {
            PROPERTY_START_INDEX = PropertyRanges.PROPERTY_REGISTRATION_START_INDEX,
            PROPERTY_END_INDEX = View.PropertyRange.PROPERTY_START_INDEX + 1000
        }

        /// <summary>
        /// Sets the unselected button image.
        /// </summary>
        public string UnselectedIcon
        {
            set
            {
                SetProperty(PushButton.Property.UNSELECTED_ICON, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// Sets the selected button image.
        /// </summary>
        public string SelectedIcon
        {
            set
            {
                SetProperty(PushButton.Property.SELECTED_ICON, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// Sets the icon alignment.
        /// </summary>
        public IconAlignmentType IconAlignment
        {
            get
            {
                string temp;
                if (GetProperty(PushButton.Property.ICON_ALIGNMENT).Get(out temp) == false)
                {
#if DEBUG_ON
                    Tizen.Log.Error("NUI", "IconAlignment get error!");
#endif
                }
                 switch (temp)
                {
                    case "LEFT":
                        return IconAlignmentType.Left;
                    case "RIGHT":
                        return IconAlignmentType.Right;
                    case "TOP":
                        return IconAlignmentType.Top;
                    case "BOTTOM":
                        return IconAlignmentType.Bottom;
                    default:
                        return IconAlignmentType.Default;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case IconAlignmentType.Left:
                    {
                        valueToString = "LEFT";
                        break;
                    }
                    case IconAlignmentType.Right:
                    {
                        valueToString = "RIGHT";
                        break;
                    }
                    case IconAlignmentType.Top:
                    {
                        valueToString = "TOP";
                        break;
                    }
                    case IconAlignmentType.Bottom:
                    {
                        valueToString = "BOTTOM";
                        break;
                    }
                    default:
                    {
                        valueToString = "DEFAULT";
                        break;
                    }
                }
                SetProperty(PushButton.Property.ICON_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        }
        /// <summary>
        /// Sets the label padding value.
        /// </summary>
        public Vector4 LabelPadding
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(PushButton.Property.LABEL_PADDING).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(PushButton.Property.LABEL_PADDING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Sets the icon padding value.
        /// </summary>
        public Vector4 IconPadding
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(PushButton.Property.ICON_PADDING).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(PushButton.Property.ICON_PADDING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Enumeration for the alignment modes of the icon.
        /// </summary>
        public enum IconAlignmentType
        {
            /// <summary>
            /// Icon located to the left of text.
            /// </summary>
            Left,
            /// <summary>
            /// Icon located to the right of text.
            /// </summary>
            Right,
            /// <summary>
            /// Icon located to the top of text.
            /// </summary>
            Top,
            /// <summary>
            /// Icon located to the bottom of text.
            /// </summary>
            Bottom,
            /// <summary>
            /// Icon located to the right of text by default.
            /// </summary>
            Default = Right
        }

    }

}
