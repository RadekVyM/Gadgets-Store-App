package crc643f46942d9dd1fff9;


public class RadioButtonRenderer
	extends androidx.appcompat.widget.AppCompatRadioButton
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnAttachStateChangeListener,
		android.view.View.OnFocusChangeListener,
		android.view.View.OnClickListener,
		android.view.View.OnTouchListener,
		android.widget.CompoundButton.OnCheckedChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"n_onViewAttachedToWindow:(Landroid/view/View;)V:GetOnViewAttachedToWindow_Landroid_view_View_Handler:Android.Views.View/IOnAttachStateChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onViewDetachedFromWindow:(Landroid/view/View;)V:GetOnViewDetachedFromWindow_Landroid_view_View_Handler:Android.Views.View/IOnAttachStateChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onFocusChange:(Landroid/view/View;Z)V:GetOnFocusChange_Landroid_view_View_ZHandler:Android.Views.View/IOnFocusChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onCheckedChanged:(Landroid/widget/CompoundButton;Z)V:GetOnCheckedChanged_Landroid_widget_CompoundButton_ZHandler:Android.Widget.CompoundButton/IOnCheckedChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.RadioButtonRenderer, Xamarin.Forms.Platform.Android", RadioButtonRenderer.class, __md_methods);
	}


	public RadioButtonRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == RadioButtonRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.RadioButtonRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public RadioButtonRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == RadioButtonRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.RadioButtonRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public RadioButtonRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == RadioButtonRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.RadioButtonRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


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


	public void onFocusChange (android.view.View p0, boolean p1)
	{
		n_onFocusChange (p0, p1);
	}

	private native void n_onFocusChange (android.view.View p0, boolean p1);


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


	public void onCheckedChanged (android.widget.CompoundButton p0, boolean p1)
	{
		n_onCheckedChanged (p0, p1);
	}

	private native void n_onCheckedChanged (android.widget.CompoundButton p0, boolean p1);

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
