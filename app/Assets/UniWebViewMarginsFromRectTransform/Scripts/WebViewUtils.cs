/*
 * UniWebViewMarginsFromRectTransform は下記のサイト様のスクリプトを使用させていただいております
 * https://qiita.com/fukaken5050/items/b0d0183c3c61630d9473
 */
using UnityEngine;

namespace UniWebViewMarginsFromRectTransform
{
	/// <summary>
	/// WebView に関する汎用機能を管理するクラス
	/// </summary>
	public static class WebViewUtils
	{
		//==============================================================================
		// 構造体
		//==============================================================================
		/// <summary>
		/// マージンの情報を管理する構造体
		/// </summary>
		public struct Margins
		{
			public int left		;
			public int top		;
			public int right	;
			public int bottom	;

			public Margins
			(
				int left	,
				int top		,
				int right	,
				int bottom
			)
			{
				this.left	= left		;
				this.top	= top		;
				this.right	= right		;
				this.bottom	= bottom	;
			}
		}

		//==============================================================================
		// 関数(static)
		//==============================================================================
		/// <summary>
		/// 指定された RectTransform のサイズに合わせて WebView のマージンを返します
		/// </summary>
		public static Rect ToMargins( RectTransform rectTrans )
		{
			var canvas	= rectTrans.GetComponentInParent<Canvas>();
			var camera	= canvas.worldCamera;
			var corners	= new Vector3[ 4 ];

			rectTrans.GetWorldCorners( corners );

			var screenCorner1 = RectTransformUtility.WorldToScreenPoint( camera, corners[ 1 ] );
			var screenCorner3 = RectTransformUtility.WorldToScreenPoint( camera, corners[ 3 ] );

			var rect = new Rect();

			rect.x		= screenCorner1.x;
			rect.width	= screenCorner3.x - rect.x;
			rect.y		= screenCorner3.y;
			rect.height	= screenCorner1.y - rect.y;

			var margins = new Margins
			(
				left	: ( int )rect.xMin,
				top		: ( int )rect.yMin,
				right	: Screen.width  - ( int )rect.xMax,
				bottom	: Screen.height - ( int )rect.yMax
			);

			return rect;
		}
	}
}