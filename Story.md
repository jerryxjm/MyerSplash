#MyerSplash UWP 背后的故事

对我甚至是大多数开发者来说，编程的最大动力就是自己的需求——因为自己需要这个东西，所以我就动手做了。

我一直是一个壁纸控，但是在壁纸的选取和使用方面，我是有这样的“洁癖”的：

- 喜欢自然风景类的；
- 喜欢写实的，也就是不虚假，后期处理要有限度；
- 喜欢独一无二的；
- 桌面必须隐藏桌面图标；


Bing 壁纸是一个不错的选择，但是每天只更新一张壁纸同时每天更新的也不一定符合口味（比如有时候会突然冒出一只两栖动物的大头照 lol）。在此推荐一下一个小伙伴开发的碧影壁纸（这个名字也是有故事的~~），在 Windows Store 搜索碧影壁纸或者 Bingo 即可。

在好几个月之前，在@优秀网页设计 的微博里，发现了好几个可以免费商用的图片网站，Unsplash 就是其中一个，而且是最符合我的品味的：

> 照片都是拍摄的，有一定的后期（比如黑白和一些颜色的处理等），而且里面的构图什么我的认为很不错，总体来说品味还是非常高的。

然后一直隔一段时间去 Unsplash 搜搜壁纸，来上班的时候换一张喜欢的壁纸心情有多好这个实在难以描述~不过老是去网站搜图也挺麻烦的（特别是对于移动设备来说），因此在用久了之后，“做一个客户端”的想法也自然慢慢建立了。然而，直到 iOS 上出名的 Cuto 应用火了我才知道原来 Unsplash 是开放 API 的，因此不需要通过扒网页的形式就能轻松获得网站的图片。

OK，那么做一个出来其实是可能的——但是应该做怎样的产品出来？

思考了一下：

- UI/UX 要独特；

> Composition API 的动画部分了解得差不多了，但是还没有一个完整的公开应用去使用这个 Composition API 做动画，那么还是值得一试的：刚好我用上了 Android 端的 WallSplash app，觉得这个 app 的动画不错，可以参考一下。

- 提供 Unsplash Public 部分的照片：

> 减少其他入口，就一个列表就够了；

- 直接应用内对照片进行下载；
- 标记“喜欢”以便下次找到：

> 有的时候，遇见喜欢的照片但是不方便下载（比如在外使用移动网络），标记一下以便之后找到。

- 提供 URL 复制，方便 Windows 桌面端粘贴到其他下载器下载：

> Unsplash 提供多种壁纸尺寸，但是真的适合做壁纸的，图像尺寸和文件大小还是挺大的（1-3MB，JPEG），提供一个 URL 方便桌面用户粘贴到下载工具下载还是不错。

刚好，之前在做毕业设计的时候做了一些新尝试，反正毕设做的应用不适合上线，那么换个产品好了，就用之前做的轮子造车。

于是，MyerSplash 就出来了，这是第三个 Myer 系列的应用。

这个名字起得有点简单直接：Unsplash 官方说使用他们 API 的应用不能用他们的 Logo 和名字，对于一个壁纸应用我也不知道叫啥好，那么取 Unsplash 里的 Splash 然后加入到 Myer 系列就刚刚好了~

这大概就是 MyerSplash 背后的一些故事，当然目前应用还处于隐藏的BETA 版本，需要的同学可以点[这里](https://www.microsoft.com/zh-cn/store/apps/myersplash/9nblggh4vcsn)下载，遇到什么问题也欢迎告诉我~
