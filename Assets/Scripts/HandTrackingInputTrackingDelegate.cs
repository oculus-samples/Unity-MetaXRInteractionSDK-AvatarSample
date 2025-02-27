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

namespace Oculus.Interaction.AvatarIntegration
{
    public class HandTrackingInputTrackingDelegate : IOvrAvatarInputTrackingDelegate
    {
        private IHand _leftHand;
        private IHand _rightHand;
        private IHmd _hmd;

        public HandTrackingInputTrackingDelegate(IHand leftHand, IHand rightHand, IHmd hmd)
        {
            _leftHand = leftHand;
            _rightHand = rightHand;
            _hmd = hmd;
        }

        public bool GetInputTrackingState(
            out OvrAvatarInputTrackingState inputTrackingState)
        {
            inputTrackingState = default;

            bool hasData = false;
            if (_hmd.TryGetRootPose(out Pose headPose))
            {
                inputTrackingState.headsetActive = true;
                inputTrackingState.headset =
                    InteractionAvatarConversions.PoseToAvatarTransform(headPose);
                hasData = true;
            }

            if (_leftHand.GetRootPose(out Pose leftHandRootPose))
            {
                inputTrackingState.leftControllerActive = true;
                inputTrackingState.leftController =
                    InteractionAvatarConversions.PoseToAvatarTransform(leftHandRootPose);
                hasData = true;
            }

            if (_rightHand.GetRootPose(out Pose rightHandRootPose))
            {
                inputTrackingState.rightControllerActive = true;
                inputTrackingState.rightController =
                    InteractionAvatarConversions.PoseToAvatarTransform(rightHandRootPose);
                hasData = true;
            }

            return hasData;
        }
    }
}
