(()=>{var e={};e.id=32,e.ids=[32],e.modules={7849:e=>{"use strict";e.exports=require("next/dist/client/components/action-async-storage.external")},2934:e=>{"use strict";e.exports=require("next/dist/client/components/action-async-storage.external.js")},5403:e=>{"use strict";e.exports=require("next/dist/client/components/request-async-storage.external")},4580:e=>{"use strict";e.exports=require("next/dist/client/components/request-async-storage.external.js")},4749:e=>{"use strict";e.exports=require("next/dist/client/components/static-generation-async-storage.external")},5869:e=>{"use strict";e.exports=require("next/dist/client/components/static-generation-async-storage.external.js")},399:e=>{"use strict";e.exports=require("next/dist/compiled/next-server/app-page.runtime.prod.js")},1017:e=>{"use strict";e.exports=require("path")},7310:e=>{"use strict";e.exports=require("url")},2852:(e,t,r)=>{"use strict";r.r(t),r.d(t,{GlobalError:()=>n.a,__next_app__:()=>p,originalPathname:()=>u,pages:()=>d,routeModule:()=>g,tree:()=>c});var o=r(482),s=r(9108),a=r(2563),n=r.n(a),i=r(8300),l={};for(let e in i)0>["default","tree","pages","GlobalError","originalPathname","__next_app__","routeModule"].indexOf(e)&&(l[e]=()=>i[e]);r.d(t,l);let c=["",{children:["pages",{children:["redirect",{children:["__PAGE__",{},{page:[()=>Promise.resolve().then(r.bind(r,267)),"D:\\Proyectos\\Portafolio (proyectos y arte)\\client\\src\\app\\pages\\redirect\\page.tsx"]}]},{}]},{metadata:{icon:[async e=>(await Promise.resolve().then(r.bind(r,3881))).default(e)],apple:[],openGraph:[],twitter:[],manifest:void 0}}]},{layout:[()=>Promise.resolve().then(r.bind(r,3329)),"D:\\Proyectos\\Portafolio (proyectos y arte)\\client\\src\\app\\layout.tsx"],"not-found":[()=>Promise.resolve().then(r.t.bind(r,9361,23)),"next/dist/client/components/not-found-error"],metadata:{icon:[async e=>(await Promise.resolve().then(r.bind(r,3881))).default(e)],apple:[],openGraph:[],twitter:[],manifest:void 0}}],d=["D:\\Proyectos\\Portafolio (proyectos y arte)\\client\\src\\app\\pages\\redirect\\page.tsx"],u="/pages/redirect/page",p={require:r,loadChunk:()=>Promise.resolve()},g=new o.AppPageRouteModule({definition:{kind:s.x.APP_PAGE,page:"/pages/redirect/page",pathname:"/pages/redirect",bundlePath:"",filename:"",appPaths:[]},userland:{loaderTree:c}})},5010:(e,t,r)=>{Promise.resolve().then(r.bind(r,6653))},6653:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>d});var o=r(5344),s=r(3729),a=r(2577);let n=e=>{let t=!0,[r,n]=(0,s.useState)();return(0,s.useEffect)(()=>{(async()=>{try{if(e.code&&t){console.log(e.code),t=!1;let o=await fetch(`${a.QP}/user/login?code=${e.code}`,{method:"GET"});o.ok||console.error(`Error en la solicitud: ${o.statusText}`);let s=await o.json();localStorage.setItem("token",s.token),localStorage.setItem("rtoken",s.refreshToken),localStorage.setItem("email",s.user.email),localStorage.setItem("user",JSON.stringify(s.user)),null==r&&n(s.user),console.log("Data:",s)}}catch(e){console.error("Error al obtener el usuario:",e)}})()},[e.code]),o.jsx("div",{children:r?(0,o.jsxs)("h1",{children:["Te Logueaste con exito ",r?.name]}):o.jsx("h1",{children:"Loading..."})})},i=e=>{let t=!0,[r,n]=(0,s.useState)();return(0,s.useEffect)(()=>{(async()=>{try{if(e.code&&t){console.log(e.code),t=!1;let o=await fetch(`${a.QP}/user?code=${e.code}`,{method:"POST"});o.ok||console.error(`Error en la solicitud: ${o.statusText}`);let s=await o.json();localStorage.setItem("token",s.token),localStorage.setItem("rtoken",s.refreshToken),localStorage.setItem("email",s.user.email),localStorage.setItem("user",JSON.stringify(s.user)),null==r&&n(s.user),console.log("Data:",s)}}catch(e){console.error("Error al obtener el usuario:",e)}})()},[e.code]),o.jsx("div",{children:r?(0,o.jsxs)("h1",{children:["Te Logueaste con exito ",r?.name]}):o.jsx("h1",{children:"Loading..."})})};var l=r(8428);let c=()=>{let[e,t]=(0,s.useState)(0),r=(0,l.useSearchParams)().get("code"),a=(0,l.useSearchParams)().get("signin");return(0,s.useEffect)(()=>{a?t(2):t(1)},[a]),o.jsx("div",{children:1==e?o.jsx("div",{children:o.jsx(n,{code:r})}):2==e?o.jsx("div",{children:o.jsx(i,{code:r})}):null})};function d(){return o.jsx(s.Suspense,{fallback:o.jsx("div",{children:"Loading..."}),children:o.jsx(c,{})})}},267:(e,t,r)=>{"use strict";r.r(t),r.d(t,{$$typeof:()=>a,__esModule:()=>s,default:()=>n});let o=(0,r(6843).createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\app\pages\redirect\page.tsx`),{__esModule:s,$$typeof:a}=o,n=o.default},3881:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>s});var o=r(337);let s=e=>[{type:"image/x-icon",sizes:"463x475",url:(0,o.fillMetadataSegment)(".",e.params,"favicon.ico")+""}]}};var t=require("../../../webpack-runtime.js");t.C(e);var r=e=>t(t.s=e),o=t.X(0,[638,351,337,955],()=>r(2852));module.exports=o})();