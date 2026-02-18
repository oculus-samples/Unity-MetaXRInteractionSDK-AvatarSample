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

using Meta.XR.Samples;
using Oculus.Avatar2;
using UnityEngine;

namespace Oculus.Interaction.AvatarIntegration
{
    [MetaCodeSample("ISDK-AvatarIntegration")]
    public class InteractionAvatarConversions
    {
        public static CAPI.ovrAvatar2Transform PoseToAvatarTransform(Pose pose)
        {
            return new CAPI.ovrAvatar2Transform(
                pose.position,
                pose.rotation
            );
        }

        public static CAPI.ovrAvatar2Transform PoseToAvatarTransformFlipZ(Pose pose)
        {
            CAPI.ovrAvatar2Vector3f position =
                new CAPI.ovrAvatar2Vector3f
                {
                    x = pose.position.x,
                    y = pose.position.y,
                    z = -pose.position.z
                };

            CAPI.ovrAvatar2Quatf orientation =
                new CAPI.ovrAvatar2Quatf
                {
                    w = pose.rotation.w,
                    x = -pose.rotation.x,
                    y = -pose.rotation.y,
                    z = pose.rotation.z
                };

            return new CAPI.ovrAvatar2Transform(position, orientation);
        }

        public static CAPI.ovrAvatar2Quatf UnityToAvatarQuaternionFlipX(Quaternion quat)
        {
            return new CAPI.ovrAvatar2Quatf
            {
                w = quat.w,
                x = quat.x,
                y = -quat.y,
                z = -quat.z
            };
        }
    }
}
