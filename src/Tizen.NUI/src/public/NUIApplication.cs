/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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

using System;
using Tizen.Applications;
using Tizen.NUI;

namespace Tizen.NUI
{

    /// <summary>
    /// Represents an application that have UI screen. The NUIApplication class has a default stage.
    /// </summary>
    public class NUIApplication : CoreUIApplication
    {
        /// <summary>
        /// The instance of the Application.
        /// </summary>
        /// <remarks>
        /// This application is created before OnCreate() or created event. And the NUIApplication will be terminated when this application is closed.
        /// </remarks>
        private Application _application;

        /// <summary>
        /// The instance of the Dali Application extension.
        /// </summary>
        private ApplicationExtensions _applicationExt;

        /// <summary>
        /// Store the stylesheet value.
        /// </summary>
        private string _stylesheet;

        /// <summary>
        /// Store the window mode value.
        /// </summary>
        private Application.WindowMode _windowMode;

        /// <summary>
        /// Store the app mode value.
        /// </summary>
        private AppMode _appMode;

        /// <summary>
        /// The instance of the Dali Stage.
        /// </summary>
        private Window _window;

        /// <summary>
        /// The default constructor.
        /// </summary>
        public NUIApplication() : base()
        {
            _appMode = AppMode.Default;
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIApplication(string stylesheet) : base()
        {
            //handle the stylesheet
            _appMode = AppMode.StyleSheetOnly;
            _stylesheet = stylesheet;
        }

        /// <summary>
        /// The constructor with stylesheet and window mode.
        /// </summary>
        public NUIApplication(string stylesheet, WindowMode windowMode) : base()
        {
            //handle the stylesheet and windowMode
            _appMode = AppMode.StyleSheetWithWindowMode;
            _stylesheet = stylesheet;
            _windowMode = (Application.WindowMode)windowMode;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            _applicationExt.Pause();
            NUILog.Debug("OnPause() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior before calling OnCreate().<br>
        /// stage property is initialized in this overrided method.<br>
        /// </summary>
        protected override void OnPreCreate()
        {
            // Initialize DisposeQueue Singleton class.
            DisposeQueue disposeQ = DisposeQueue.Instance;
            NUILog.Debug("1) DisposeQueue.Instance.Initialize()!");
            switch (_appMode)
            {
                case AppMode.Default:
                    _application = Tizen.NUI.Application.NewApplication();
                    break;
                case AppMode.StyleSheetOnly:
                    _application = Tizen.NUI.Application.NewApplication(_stylesheet);
                    break;
                case AppMode.StyleSheetWithWindowMode:
                    _application = Tizen.NUI.Application.NewApplication(_stylesheet, _windowMode);
                    break;
                default:
                    break;
            }
            _applicationExt = new ApplicationExtensions(_application);
            _applicationExt.Init();
            _applicationExt.Start();

            // This is also required to create DisposeQueue on main thread.
            disposeQ.Initialize();
            NUILog.Debug("2) DisposeQueue.Instance.Initialize()!");
            _window = Window.Instance;
            _window.SetBackgroundColor(Color.White);
            NUILog.Debug("OnPreCreate() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            _applicationExt.Resume();
            NUILog.Debug("OnResume() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            base.OnAppControlReceived(e);
            NUILog.Debug("OnAppControlReceived() is called!");
            if (e != null)
            {
                NUILog.Debug("OnAppControlReceived() is called! ApplicationId=" + e.ReceivedAppControl.ApplicationId);
                NUILog.Debug("CallerApplicationId=" + e.ReceivedAppControl.CallerApplicationId + "   IsReplyRequest=" + e.ReceivedAppControl.IsReplyRequest);
            }
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnCreate()
        {
            base.OnCreate();
            NUILog.Debug("OnCreate() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
            _applicationExt.LanguageChange();
            NUILog.Debug("OnLocaleChanged() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            base.OnLowBattery(e);
            NUILog.Debug("OnLowBattery() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            base.OnLowMemory(e);
            NUILog.Debug("OnLowMemory() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            base.OnRegionFormatChanged(e);
            NUILog.Debug("OnRegionFormatChanged() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnTerminate()
        {
            base.OnTerminate();
            _applicationExt.Terminate();
            NUILog.Debug("OnTerminate() is called!");
        }

        /// <summary>
        /// The mode of creating NUI application.
        /// </summary>
        private enum AppMode
        {
            Default = 0,
            StyleSheetOnly = 1,
            StyleSheetWithWindowMode = 2
        }

        /// <summary>
        /// Enumeration for deciding whether a NUI application window is opaque or transparent.
        /// </summary>
        public enum WindowMode
        {
            Opaque = 0,
            Transparent = 1
        }

        /// <summary>
        /// Get the window instance.
        /// </summary>
        public Window Window
        {
            get
            {
                return _application.GetWindow();
            }
        }

        internal Application ApplicationHandle
        {
            get
            {
                return _application;
            }
        }
    }
}
