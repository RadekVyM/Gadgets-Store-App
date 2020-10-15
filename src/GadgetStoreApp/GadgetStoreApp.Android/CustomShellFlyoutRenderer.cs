using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Widget;
using Android.Views;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;
using LP = Android.Views.ViewGroup.LayoutParams;

namespace GadgetStoreApp.Droid
{
    public class CustomShellFlyoutRenderer : DrawerLayout, IShellFlyoutRenderer, DrawerLayout.IDrawerListener, IFlyoutBehaviorObserver, IAppearanceObserver
	{
		#region IAppearanceObserver

		void IAppearanceObserver.OnAppearanceChanged(ShellAppearance appearance)
		{
			if (appearance == null)
				UpdateScrim(Brush.Transparent);
			else
			{
				UpdateScrim(appearance.FlyoutBackdrop);
			}
		}
		#endregion IAppearanceObserver

		#region IShellFlyoutRenderer

		AView IShellFlyoutRenderer.AndroidView => this;

		void IShellFlyoutRenderer.AttachFlyout(IShellContext context, AView content)
		{
			AttachFlyout(context, content);
		}

		#endregion IShellFlyoutRenderer

		#region IDrawerListener

		void IDrawerListener.OnDrawerClosed(AView drawerView)
		{
			Shell.SetValueFromRenderer(Shell.FlyoutIsPresentedProperty, false);
		}

		void IDrawerListener.OnDrawerOpened(AView drawerView)
		{
			Shell.SetValueFromRenderer(Shell.FlyoutIsPresentedProperty, true);
		}

		void IDrawerListener.OnDrawerSlide(AView drawerView, float slideOffset)
		{
			_scrimOpacity = (int)0;
		}

		void IDrawerListener.OnDrawerStateChanged(int newState)
		{
			if (DrawerLayout.StateIdle == newState)
			{
				Shell.SetValueFromRenderer(Shell.FlyoutIsPresentedProperty, false);
			}
		}

		#endregion IDrawerListener

		#region IFlyoutBehaviorObserver

		void IFlyoutBehaviorObserver.OnFlyoutBehaviorChanged(FlyoutBehavior behavior)
		{
			_behavior = behavior;
			UpdateDrawerLockMode(behavior);
		}

		#endregion IFlyoutBehaviorObserver

		const uint DefaultScrimColor = 0x99000000;
		readonly IShellContext _shellContext;
		AView _content;
		IShellFlyoutContentRenderer _flyoutContent;
		int _flyoutWidth;
		int _currentLockMode;
		bool _disposed;
		Brush _scrimBrush;
		Paint _scrimPaint;
		int _previousHeight;
		int _previousWidth;
		int _scrimOpacity;

		FlyoutBehavior _behavior;

		public CustomShellFlyoutRenderer(IShellContext shellContext, Context context) : base(context)
		{
			_scrimBrush = Brush.Default;
			_shellContext = shellContext;

			Shell.PropertyChanged += OnShellPropertyChanged;

			ShellController.AddAppearanceObserver(this, Shell);
		}

		Shell Shell => _shellContext.Shell;

		IShellController ShellController => _shellContext.Shell;

		public override bool OnInterceptTouchEvent(MotionEvent ev)
		{
			bool result = base.OnInterceptTouchEvent(ev);

			if (GetDrawerLockMode(_flyoutContent.AndroidView) == LockModeLockedOpen)
				return false;

			return result;
		}

		protected override bool DrawChild(Canvas canvas, AView child, long drawingTime)
		{
			bool returnValue = base.DrawChild(canvas, child, drawingTime);
			if (_scrimPaint != null && ((LayoutParams)child.LayoutParameters).Gravity == (int)GravityFlags.NoGravity)
			{
				if (_previousHeight != Height || _previousWidth != Width)
				{
					_scrimPaint.UpdateBackground(_scrimBrush, Height, Width);
					_previousHeight = Height;
					_previousWidth = Width;
				}

				_scrimPaint.Alpha = _scrimOpacity;
				canvas.DrawRect(0, 0, Width, Height, _scrimPaint);
			}

			return returnValue;
		}

		protected virtual void AttachFlyout(IShellContext context, AView content)
		{
			Profile.FrameBegin();

			_content = content;

			_flyoutContent = context.CreateShellFlyoutContentRenderer();

			_flyoutWidth = 1;

			_flyoutContent.AndroidView.LayoutParameters =
				new LayoutParams(1, LP.MatchParent) { Gravity = (int)GravityFlags.Start };

			AddView(content);

			AddView(_flyoutContent.AndroidView);

			AddDrawerListener(this);

			((IShellController)context.Shell).AddFlyoutBehaviorObserver(this);

			Profile.FrameEnd();
		}

		protected virtual void OnShellPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Shell.FlyoutIsPresentedProperty.PropertyName)
			{
				if (Shell.FlyoutIsPresented)
					Shell.ChangeCustomFlyoutVisibility(true);
				CloseDrawers();
			}
		}

		protected virtual void UpdateDrawerLockMode(FlyoutBehavior behavior)
		{
			switch (behavior)
			{
				case FlyoutBehavior.Disabled:
					CloseDrawers();
					Shell.SetValueFromRenderer(Shell.FlyoutIsPresentedProperty, false);
					_currentLockMode = LockModeLockedClosed;
					SetDrawerLockMode(_currentLockMode);
					_content.SetPadding(0, _content.PaddingTop, _content.PaddingRight, _content.PaddingBottom);
					break;

				case FlyoutBehavior.Flyout:
					_currentLockMode = LockModeUnlocked;
					SetDrawerLockMode(_currentLockMode);
					_content.SetPadding(0, _content.PaddingTop, _content.PaddingRight, _content.PaddingBottom);
					break;

				case FlyoutBehavior.Locked:
					Shell.SetValueFromRenderer(Shell.FlyoutIsPresentedProperty, true);
					_currentLockMode = LockModeLockedOpen;
					SetDrawerLockMode(_currentLockMode);
					_content.SetPadding(_flyoutWidth, _content.PaddingTop, _content.PaddingRight, _content.PaddingBottom);
					break;
			}

			UpdateScrim(_scrimBrush);
		}

		void UpdateScrim(Brush backdrop)
		{
			_scrimBrush = backdrop;

			SetScrimColor(Xamarin.Forms.Color.Transparent.ToAndroid());
			_scrimPaint = null;
		}

		protected override void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			_disposed = true;

			if (disposing)
			{
				ShellController.RemoveAppearanceObserver(this);
				Shell.PropertyChanged -= OnShellPropertyChanged;

				RemoveDrawerListener(this);
				((IShellController)_shellContext.Shell).RemoveFlyoutBehaviorObserver(this);

				RemoveView(_content);
				RemoveView(_flyoutContent.AndroidView);

				_flyoutContent.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}