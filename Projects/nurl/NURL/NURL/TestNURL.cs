/*
 * Created by SharpDevelop.
 * User: Charly-PC
 * Date: 29/05/2014
 * Time: 16:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using NUnit.Framework;

namespace NURL
{
	[TestFixture]
	public class TestNURL
	{
		[Test]
		public void Should_return_false_with_a_fake_URL()
		{
			NUrl getWebsite = new NUrl();
			Assert.AreEqual(false, getWebsite.isValidUrl("http://fake"));
		}
		
		[Test]
		public void Should_return_true_with_a_true_URL()
		{
			NUrl getWebsite = new NUrl();
			Assert.AreEqual(true, getWebsite.isValidUrl("http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric"));
		}
		
		[Test] 
		public void The_result_should_be_a_string()
		{
			NUrl getWebsite = new NUrl();
			var str = getWebsite.UrlContent("http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric");
			Assert.AreEqual(typeof(string), str.GetType());
		}
		
		[Test]
		public void Content_fake_url()
		{
			NUrl getWebsite = new NUrl();
			var str = getWebsite.UrlContent("http://fake");
			Assert.AreEqual("Invalid URL", str);
		}
		
		[Test]
		public void Content_like_browser()
		{
			NUrl getWebsite = new NUrl();
			var str = getWebsite.UrlContent("http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric");
			WebClient browser = new WebClient();
			Assert.AreEqual(str, browser.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric"));
		}
	}
}
