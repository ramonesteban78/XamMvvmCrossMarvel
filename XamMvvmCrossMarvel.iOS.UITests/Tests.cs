using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace XamMvvmCrossMarvel.iOS.UITests
{
	[TestFixture]
	public class Tests
	{
		iOSApp app;

		[SetUp]
		public void BeforeEachTest ()
		{
			app = ConfigureApp.iOS.StartApp ();
		}

		[Test]
		public void OpenSecondTab ()
		{
			app.Tap (c => c.Marked ("Second"));
			AppResult[] results = app.WaitForElement (c => c.Marked ("Second View"));
			app.Screenshot ("Second tab is opened.");

			Assert.IsTrue (results.Any ());
		}
	}
}


