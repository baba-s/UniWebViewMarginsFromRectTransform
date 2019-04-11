# UniWebViewMarginsFromRectTransform

[unity-webview](https://github.com/gree/unity-webview) のマージンを RectTranform から設定できる機能

[![](https://img.shields.io/github/release/baba-s/uni-web-view-margins-from-rect-transform.svg?label=latest%20version)](https://github.com/baba-s/uni-web-view-margins-from-rect-transform/releases)
[![](https://img.shields.io/github/release-date/baba-s/uni-web-view-margins-from-rect-transform.svg)](https://github.com/baba-s/uni-web-view-margins-from-rect-transform/releases)
![](https://img.shields.io/badge/Unity-2018.3%2B-red.svg)
![](https://img.shields.io/badge/.NET-4.x-orange.svg)
[![](https://img.shields.io/github/license/baba-s/uni-web-view-margins-from-rect-transform.svg)](https://github.com/baba-s/uni-web-view-margins-from-rect-transform/blob/master/LICENSE)

## バージョン

- Unity 2018.3.11f1

## 使い方

```cs
var rectTransform = GetComponent<RectTransform>();
var margins = WebViewUtils.ToMargins( rectTransform );

m_webViewObject.SetMargins
( 
    left    : margins.left  , 
    top     : margins.top   , 
    right   : margins.right , 
    bottom  : margins.bottom 
);
```

WebViewUtils.ToMargins に RectTransform を渡して、  
取得できた値を WebViewObject.SetMargins に渡すことで、  
RectTransform の範囲に WebView を表示できます　　

## 謝辞

 - UniWebViewMarginsFromRectTransform は下記のサイト様のスクリプトを使用させていただいております
 https://qiita.com/fukaken5050/items/b0d0183c3c61630d9473