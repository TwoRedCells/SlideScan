#region Licence

// Distributed under MIT License
// ===========================================================
// 
// digiCamControl - DSLR camera remote control open source software
// Copyright (C) 2014 Duka Istvan
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY,FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH 
// THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CameraControl.Core;
using CameraControl.Core.Classes;
using CameraControl.Devices;
using CameraControl.Devices.Classes;

namespace RedCell.App.Graphics.SlideScan
{
    public static class Camera
    {
        public static void Capture()
        {
            try
            {
                ServiceProvider.DeviceManager.SelectedCameraDevice.IsBusy = true;
                ServiceProvider.DeviceManager.SelectedCameraDevice.CaptureInSdRam = true;
                // prevent use this mode if the camera not support it 
                if (ServiceProvider.DeviceManager.SelectedCameraDevice.GetCapability(CapabilityEnum.CaptureInRam))
                    ServiceProvider.DeviceManager.SelectedCameraDevice.CaptureInSdRam = false;
                ServiceProvider.DeviceManager.SelectedCameraDevice.CapturePhoto();
            }
            finally
            {
                ServiceProvider.DeviceManager.SelectedCameraDevice.IsBusy = false;
            }
        }

        /// <summary>
        /// capture as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public async static Task CaptureAsync()
        {
            await Task.Run((Action)Capture);

        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public async static Task Initialize()
        {
            await Task.Run(() =>
            {
                ServiceProvider.Configure();
                var dm = ServiceProvider.DeviceManager;
                dm.UseExperimentalDrivers = false;
                dm.ConnectToCamera();
                dm.PhotoCaptured += DeviceManager_PhotoCaptured;
                Filename = "test.jpg";
            });
        }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public static string Filename { get; set; }

        public static void SetIso(string iso)
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.IsoNumber.Value = iso;
        }

        public static string[] GetIsos()
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.IsoNumber;
            return values == null ? new string[0] : values.Values.ToArray();
        }

        public static string GetIso()
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.IsoNumber;
            return values == null ? null : values.Value;
        }

        public static void SetAperture(string aperture)
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.FNumber.Value = "f/" + aperture;
        }

        public static string[] GetApertures()
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.FNumber;
            return values == null ? new string[0] : values.Values.ToArray();
        }

        public static string GetAperture()
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.FNumber;
            return values == null ? null : values.Value;
        }

        public static void SetShutterSpeed(string speed)
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.ShutterSpeed.Value = speed;
        }

        public static string[] GetShutterSpeeds()
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.ShutterSpeed;
            return values == null ? new string[0] : values.Values.ToArray();
        }

        public static string GetShutterSpeed()
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.ShutterSpeed;
            return values == null ? null : values.Value;
        }

        public static void SetExposureCompensation(string value)
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.ExposureCompensation.Value = value;
        }

        public static string[] GetExposureCompensations()
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.ExposureCompensation;
            return values == null ? new string[0] : values.Values.ToArray();
        }

        public static string GetExposureCompensation()
        {
            var values = ServiceProvider.DeviceManager.SelectedCameraDevice.ExposureCompensation;
            return values == null ? null : values.Value;
        }

        private async static void DeviceManager_PhotoCaptured(object sender, PhotoCapturedEventArgs e)
        {
            await PhotoCaptured(e);
        }

        private async static Task PhotoCaptured(PhotoCapturedEventArgs e)
        {
            await Task.Run(() =>
                {
                    try
                    {
                        string tempFile = Path.GetTempFileName();

                        if (File.Exists(tempFile))
                            File.Delete(tempFile);

                        e.CameraDevice.TransferFile(e.Handle, tempFile);
                        File.Copy(tempFile, Filename, true);

                        if (File.Exists(tempFile))
                            File.Delete(tempFile);
                    }
                    finally
                    {
                        e.CameraDevice.IsBusy = false;
                    }
                });
        }

        public static ICameraDevice GetDevice()
        {
            return ServiceProvider.DeviceManager.SelectedCameraDevice;
        }

    }
}