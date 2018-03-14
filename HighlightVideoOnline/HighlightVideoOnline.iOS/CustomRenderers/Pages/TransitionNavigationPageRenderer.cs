﻿using CoreAnimation;
using CoreGraphics;
using HighlightVideoOnline.Commons;
using HighlightVideoOnline.CustomRender.Pages;
using HighlightVideoOnline.iOS.CustomRenderers.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TransitionNavigationPage), typeof(TransitionNavigationPageRenderer))]
namespace HighlightVideoOnline.iOS.CustomRenderers.Pages
{
    public class TransitionNavigationPageRenderer : NavigationRenderer
    {
        private TransitionType _transitionType;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;
            }
            if (e.NewElement != null)
            {
                e.NewElement.PropertyChanged += OnElementPropertyChanged;
            }
        }


        public override void PushViewController(UIViewController viewController, bool animated)
        {
            if (animated)
            {
                if (_transitionType == TransitionType.Fade)
                {
                    FadeAnimation(View);
                }
                else if (_transitionType == TransitionType.Flip)
                {
                    FlipAnimation(View);
                }
                else if (_transitionType == TransitionType.Scale)
                {
                    ScaleAnimation(View);
                }
                else
                {
                    var transition = CATransition.CreateAnimation();
                    transition.Duration = 0.5f;
                    transition.Type = CAAnimation.TransitionPush;

                    switch (_transitionType)
                    {
                        case TransitionType.SlideFromBottom:
                            transition.Subtype = CAAnimation.TransitionFromBottom;
                            break;
                        case TransitionType.SlideFromLeft:
                            transition.Subtype = CAAnimation.TransitionFromLeft;
                            break;
                        case TransitionType.SlideFromRight:
                            transition.Subtype = CAAnimation.TransitionFromRight;
                            break;
                        case TransitionType.SlideFromTop:
                            transition.Subtype = CAAnimation.TransitionFromTop;
                            break;
                    }

                    View.Layer.AddAnimation(transition, null);
                }

                base.PushViewController(viewController, false);
            }
            else
            {
                base.PushViewController(viewController, false);
            }
        }

        public override UIViewController PopViewController(bool animated)
        {
            if (animated)
            {
                if (_transitionType == TransitionType.Fade)
                {
                    FadeAnimation(View);
                }
                else if (_transitionType == TransitionType.Flip)
                {
                    FlipAnimation(View);
                }
                else if (_transitionType == TransitionType.Scale)
                {
                    ScaleAnimation(View);
                }
                else
                {
                    var transition = CATransition.CreateAnimation();
                    transition.Duration = 0.5f;
                    transition.Type = CAAnimation.TransitionPush;

                    switch (_transitionType)
                    {
                        case TransitionType.SlideFromBottom:
                            transition.Subtype = CAAnimation.TransitionFromTop;
                            break;
                        case TransitionType.SlideFromLeft:
                            transition.Subtype = CAAnimation.TransitionFromRight;
                            break;
                        case TransitionType.SlideFromRight:
                            transition.Subtype = CAAnimation.TransitionFromLeft;
                            break;
                        case TransitionType.SlideFromTop:
                            transition.Subtype = CAAnimation.TransitionFromBottom;
                            break;
                    }

                    View.Layer.AddAnimation(transition, null);
                }

                return base.PopViewController(false);
            }
            else
            {
                return base.PopViewController(false);
            }
        }

        private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TransitionNavigationPage.TransitionTypeProperty.PropertyName)
                UpdateTransitionType();
        }

        private void UpdateTransitionType()
        {
            var transitionNavigationPage = (TransitionNavigationPage)Element;
            _transitionType = transitionNavigationPage.TransitionType;
        }

        private void FadeAnimation(UIView view, double duration = 1.0)
        {
            view.Alpha = 0.0f;
            view.Transform = CGAffineTransform.MakeIdentity();

            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = 1.0f;
                },
                null
            );
        }

        public void FlipAnimation(UIView view, double duration = 0.5)
        {
            var m34 = (nfloat)(-1 * 0.001);
            var initialTransform = CATransform3D.Identity;
            initialTransform.m34 = m34;
            initialTransform = initialTransform.Rotate((nfloat)(1 * Math.PI * 0.5), 0.0f, 1.0f, 0.0f);

            view.Alpha = 0.0f;
            view.Layer.Transform = initialTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Layer.AnchorPoint = new CGPoint((nfloat)0.5, 0.5f);
                    var newTransform = CATransform3D.Identity;
                    newTransform.m34 = m34;
                    view.Layer.Transform = newTransform;
                    view.Alpha = 1.0f;
                },
                null
            );
        }

        private void ScaleAnimation(UIView view, double duration = 0.5)
        {
            view.Alpha = 0.0f;
            view.Transform = CGAffineTransform.MakeScale((nfloat)0.5, (nfloat)0.5);

            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = 1.0f;
                    view.Transform = CGAffineTransform.MakeScale((nfloat)1.0, (nfloat)1.0);
                },
                null
            );
        }
    }
}
