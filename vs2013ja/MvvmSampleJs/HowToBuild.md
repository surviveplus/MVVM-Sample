# How to build

プロジェクトを Relase ビルドすると、mvvmsample.ts ファイルなどから .d.ts ファイルと .min.js ファイルを作成します。cssファイルも結合して .min.css ファイルを作成します。

また、配布用の NuGet パッケージファイルを作成します。これをインストールして使用してください。

- Content
	- mvvmsample.min.css	（配布用）
	- mvvmsample.css	（開発中に編集）
- nupkg
	- mvvmsample.js.0.0.0.0.nupkg	（配布用 NuGetパッケージ）
- Scripts
	- typings
       	- mvvmsample
	       	- mvvmsample.ts ... 他	（開発中に編集）
	       	- mvvmsample.js ... 他	（デバッグ時中間生成ファイル - ソース管理外）
			- mvvmsample.d.ts	（配布用）
	- mvvmsample.js	（配布用）
	- mvvmsample.min.js	（配布用）
- AjaxMin.css.xml	(CSS min 作成用の定義ファイル）
- mvvmsample.nuspec	（NuGet パッケージ作成用の定義ファイル）

## NOTE
ビルドには [http://ajaxmin.codeplex.com/](http://ajaxmin.codeplex.com/ "Microsoft Ajax Minifier") が必要です。事前にインストールしてください。

ビルド対象のファイルを増やしたいときは、MSBuildタスク ReleaseTypeScript を修正してください。また、プロジェクトに出力後の tsファイルなどを追加する場合は、ビルドアクションを none に変更してください。

圧縮するCSSファイルを増やしたいときは、AjaxMin.css.xml を修正してください。
