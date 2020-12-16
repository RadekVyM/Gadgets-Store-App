package crc648e35430423bd4943;


public class SKGLTextureView_InternalRenderer
	extends crc648e35430423bd4943.SKGLTextureViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Android.SKGLTextureView+InternalRenderer, SkiaSharp.Views.Android", SKGLTextureView_InternalRenderer.class, __md_methods);
	}


	public SKGLTextureView_InternalRenderer ()
	{
		super ();
		if (getClass () == SKGLTextureView_InternalRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKGLTextureView+InternalRenderer, SkiaSharp.Views.Android", "", this, new java.lang.Object[] {  });
	}

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
