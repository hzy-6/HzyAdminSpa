(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-224eb2df","chunk-2d0b21c3","chunk-2d221c51"],{"235a":function(e,t,n){"use strict";n.r(t);var c=n("7a23"),r={id:"container1"};function a(e,t,n,a,i,o){return Object(c["E"])(),Object(c["k"])("div",r)}var i=n("917c"),o=Object(c["o"])({name:"index1",setup:function(){var e=Object(c["I"])([{year:"1951 年",sales:38},{year:"1952 年",sales:52},{year:"1956 年",sales:61},{year:"1957 年",sales:145},{year:"1958 年",sales:48},{year:"1959 年",sales:38},{year:"1960 年",sales:38},{year:"1962 年",sales:38}]),t=function(){var t=new i["a"]({container:"container1",autoFit:!0,height:500});t.data(e),t.scale("sales",{nice:!0}),t.tooltip({showMarkers:!1}),t.interaction("active-region"),t.interval().position("year*sales"),t.render()};return Object(c["B"])((function(){t()})),{data:e}}});o.render=a;t["default"]=o},3376:function(e,t,n){"use strict";n.r(t);var c=n("7a23"),r={class:"p-15"},a=Object(c["m"])("查看 AntV G2 更多示例");function i(e,t,n,i,o,u){var s=Object(c["L"])("router-link"),l=Object(c["L"])("a-alert"),b=Object(c["L"])("char1"),f=Object(c["L"])("a-card"),d=Object(c["L"])("a-col"),j=Object(c["L"])("char2"),O=Object(c["L"])("a-row");return Object(c["E"])(),Object(c["k"])("div",r,[Object(c["n"])(l,{message:"图表",type:"success"},{description:Object(c["W"])((function(){return[Object(c["n"])("p",null,[Object(c["n"])(s,{to:{name:"chart_more"}},{default:Object(c["W"])((function(){return[a]})),_:1})])]})),_:1}),Object(c["n"])(O,{gutter:[15,15],class:"pt-15"},{default:Object(c["W"])((function(){return[Object(c["n"])(d,{xs:24,sm:12,md:12,lg:12,xl:12},{default:Object(c["W"])((function(){return[Object(c["n"])(f,{hoverable:""},{default:Object(c["W"])((function(){return[Object(c["n"])(b)]})),_:1})]})),_:1}),Object(c["n"])(d,{xs:24,sm:12,md:12,lg:12,xl:12},{default:Object(c["W"])((function(){return[Object(c["n"])(f,{hoverable:""},{default:Object(c["W"])((function(){return[Object(c["n"])(j)]})),_:1})]})),_:1})]})),_:1})])}var o=n("235a"),u=n("cc83"),s=Object(c["o"])({name:"chart_base",components:{char1:o["default"],char2:u["default"]},setup:function(){return{}}});s.render=i;t["default"]=s},cc83:function(e,t,n){"use strict";n.r(t);var c=n("7a23"),r={id:"container2"};function a(e,t,n,a,i,o){return Object(c["E"])(),Object(c["k"])("div",r)}var i=n("917c"),o=Object(c["o"])({name:"index2",setup:function(){var e=Object(c["I"])([{item:"事例一",count:40,percent:.4},{item:"事例二",count:21,percent:.21},{item:"事例三",count:17,percent:.17},{item:"事例四",count:13,percent:.13},{item:"事例五",count:9,percent:.09}]),t=function(){var t=new i["a"]({container:"container2",autoFit:!0,height:500});t.data(e),t.coordinate("theta",{radius:.85}),t.scale("percent",{formatter:function(e){return e=100*e+"%",e}}),t.tooltip({showTitle:!1,showMarkers:!1}),t.axis(!1);var n=t.interval().adjust("stack").position("percent").color("item").label("percent",{offset:-40,style:{textAlign:"center",shadowBlur:2,shadowColor:"rgba(0, 0, 0, .45)",fill:"#fff"}}).tooltip("item*percent",(function(e,t){return t=100*t+"%",{name:e,value:t}})).style({lineWidth:1,stroke:"#fff"});t.interaction("element-single-selected"),t.render(),n.elements[0].setState("selected",!0)};return Object(c["B"])((function(){t()})),{}}});o.render=a;t["default"]=o}}]);
//# sourceMappingURL=chunk-224eb2df.a31922c1.js.map