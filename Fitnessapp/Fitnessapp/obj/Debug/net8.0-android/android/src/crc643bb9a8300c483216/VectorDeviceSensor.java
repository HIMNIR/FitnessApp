package crc643bb9a8300c483216;


public class VectorDeviceSensor
	extends crc643bb9a8300c483216.BaseDeviceSensor_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Plugin.DeviceSensors.Platforms.Android.VectorDeviceSensor, Plugin.DeviceSensors", VectorDeviceSensor.class, __md_methods);
	}


	public VectorDeviceSensor ()
	{
		super ();
		if (getClass () == VectorDeviceSensor.class) {
			mono.android.TypeManager.Activate ("Plugin.DeviceSensors.Platforms.Android.VectorDeviceSensor, Plugin.DeviceSensors", "", this, new java.lang.Object[] {  });
		}
	}

	public VectorDeviceSensor (android.hardware.SensorManager p0, int p1)
	{
		super ();
		if (getClass () == VectorDeviceSensor.class) {
			mono.android.TypeManager.Activate ("Plugin.DeviceSensors.Platforms.Android.VectorDeviceSensor, Plugin.DeviceSensors", "Android.Hardware.SensorManager, Mono.Android:Android.Hardware.SensorType, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
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
