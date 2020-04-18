# Uni Web View Margins From RectTransform

[unity-webview](https://github.com/gree/unity-webview) のマージンを RectTranform から設定できる機能

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