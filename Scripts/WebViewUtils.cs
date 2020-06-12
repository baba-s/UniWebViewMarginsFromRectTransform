/*
 * UniWebViewMarginsFromRectTransform は下記のサイト様のスクリプトを使用させていただいております
 * https://qiita.com/fukaken5050/items/b0d0183c3c61630d9473
 */

using System;
using UnityEngine;

namespace Kogane
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
		[Serializable]
		public struct Margins
		{
			[SerializeField] private int m_left;
			[SerializeField] private int m_top;
			[SerializeField] private int m_right;
			[SerializeField] private int m_bottom;

			public int Left   => m_left;
			public int Top    => m_top;
			public int Right  => m_right;
			public int Bottom => m_bottom;

			public Margins
			(
				int left,
				int top,
				int right,
				int bottom
			)
			{
				m_left   = left;
				m_top    = top;
				m_right  = right;
				m_bottom = bottom;
			}
		}

		//==============================================================================
		// 関数(static)
		//==============================================================================
		/// <summary>
		/// 指定された RectTransform のサイズに合わせて WebView のマージンを返します
		/// </summary>
		public static Margins ToMargins( RectTransform rectTransform )
		{
			var canvas  = rectTransform.GetComponentInParent<Canvas>();
			var camera  = canvas.worldCamera;
			var corners = new Vector3[4];

			rectTransform.GetWorldCorners( corners );

			var screenCorner1 = RectTransformUtility.WorldToScreenPoint( camera, corners[ 1 ] );
			var screenCorner3 = RectTransformUtility.WorldToScreenPoint( camera, corners[ 3 ] );

			var rect = new Rect();

			rect.x      = screenCorner1.x;
			rect.width  = screenCorner3.x - rect.x;
			rect.y      = screenCorner3.y;
			rect.height = screenCorner1.y - rect.y;

			var margins = new Margins
			(
				left: ( int ) rect.xMin,
				top: Screen.height - ( int ) rect.yMax,
				right: Screen.width - ( int ) rect.xMax,
				bottom: ( int ) rect.yMin
			);

			return margins;
		}
	}
}