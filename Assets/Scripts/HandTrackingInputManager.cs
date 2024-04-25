/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Oculus.Avatar2;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Assertions;

namespace Oculus.Interaction.AvatarIntegration
{
    public class HandTrackingInputManager : OvrAvatarInputManager
    {
        [SerializeField, Interface(typeof(IHmd))]
        private UnityEngine.Object _hmd;
        private IHmd Hmd;

        [SerializeField, Interface(typeof(IHand))]
        private UnityEngine.Object _leftHand;
        private IHand LeftHand;

        [SerializeField, Interface(typeof(IHand))]
        private UnityEngine.Object _rightHand;
        private IHand RightHand;

        private bool _setupBodyTracking = false;

        protected void Awake()
        {
            Hmd = _hmd as IHmd;
            LeftHand = _leftHand as IHand;
            RightHand = _rightHand as IHand;
        }

        protected virtual void Start()
        {
            this.AssertField(Hmd, nameof(Hmd));
            this.AssertField(LeftHand, nameof(LeftHand));
            this.AssertField(RightHand, nameof(RightHand));
        }

        private void Update()
        {
            if (!_setupBodyTracking)
            {
                if (BodyTracking == null)
                {
                    return;
                }

                BodyTracking.InputTrackingDelegate =
                    new HandTrackingInputTrackingDelegate(LeftHand, RightHand, Hmd);
                BodyTracking.HandTrackingDelegate = new HandTrackingDelegate(LeftHand, RightHand);
                _setupBodyTracking = true;
            }
        }

        #region Inject
        public void InjectAllHandTrackingInputManager(Hmd hmd, IHand leftHand, IHand rightHand)
        {
            InjectHmd(hmd);
            InjectLeftHand(leftHand);
            InjectRightHand(rightHand);
        }
        public void InjectHmd(IHmd hmd)
        {
            _hmd = hmd as UnityEngine.Object;
            Hmd = hmd;
        }
        public void InjectLeftHand(IHand leftHand)
        {
            _leftHand = leftHand as UnityEngine.Object;
            LeftHand = leftHand;
        }
        public void InjectRightHand(IHand rightHand)
        {
            _rightHand = rightHand as UnityEngine.Object;
            RightHand = rightHand;
        }
        #endregion
    }
}
