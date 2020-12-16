package crc64720bb2db43a66fe9;


public class ButtonRenderer
	extends crc64720bb2db43a66fe9.ViewRenderer_2
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnAttachStateChangeListener,
		android.view.View.OnClickListener,
		android.view.View.OnTouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"n_onViewAttachedToWindow:(Landroid/view/View;)V:GetOnViewAttachedToWindow_Landroid_view_View_Handler:Android.Views.View/IOnAttachStateChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onViewDetachedFromWindow:(Landroid/view/View;)V:GetOnViewDetachedFromWindow_Landroid_view_View_Handler:Android.Views.View/IOnAttachStateChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer, Xamarin.Forms.Platform.Android", ButtonRenderer.class, __md_methods);
	}


	public ButtonRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ButtonRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ButtonRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ButtonRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ButtonRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ButtonRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);


	public void onViewAttachedToWindow (android.view.View p0)
	{
		n_onViewAttachedToWindow (p0);
	}

	private native void n_onViewAttachedToWindow (android.view.View p0);


	public void onViewDetachedFromWindow (android.view.View p0)
	{
		n_onViewDetachedFromWindow (p0);
	}

	private native void n_onViewDetachedFromWindow (android.view.View p0);


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);


	public boolean onTouch (android.view.View p0, android.view.MotionEvent p1)
	{
		return n_onTouch (p0, p1);
	}

	private native boolean n_onTouch (android.view.View p0, android.view.MotionEvent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
