package crc6470f9ebbbdbb5b14b;


public class CustomShellItemRenderer
	extends crc643f46942d9dd1fff9.ShellItemRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onConfigurationChanged:(Landroid/content/res/Configuration;)V:GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler\n" +
			"";
		mono.android.Runtime.register ("GadgetStoreApp.Droid.CustomShellItemRenderer, GadgetStoreApp.Android", CustomShellItemRenderer.class, __md_methods);
	}


	public CustomShellItemRenderer ()
	{
		super ();
		if (getClass () == CustomShellItemRenderer.class)
			mono.android.TypeManager.Activate ("GadgetStoreApp.Droid.CustomShellItemRenderer, GadgetStoreApp.Android", "", this, new java.lang.Object[] {  });
	}


	public CustomShellItemRenderer (int p0)
	{
		super (p0);
		if (getClass () == CustomShellItemRenderer.class)
			mono.android.TypeManager.Activate ("GadgetStoreApp.Droid.CustomShellItemRenderer, GadgetStoreApp.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onConfigurationChanged (android.content.res.Configuration p0)
	{
		n_onConfigurationChanged (p0);
	}

	private native void n_onConfigurationChanged (android.content.res.Configuration p0);

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
