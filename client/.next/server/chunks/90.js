exports.id=90,exports.ids=[90],exports.modules={6649:(e,t,r)=>{Promise.resolve().then(r.bind(r,6974)),Promise.resolve().then(r.bind(r,917)),Promise.resolve().then(r.bind(r,9666)),Promise.resolve().then(r.bind(r,7429)),Promise.resolve().then(r.bind(r,9768)),Promise.resolve().then(r.bind(r,1021))},9594:(e,t,r)=>{Promise.resolve().then(r.t.bind(r,2583,23)),Promise.resolve().then(r.t.bind(r,6840,23)),Promise.resolve().then(r.t.bind(r,8771,23)),Promise.resolve().then(r.t.bind(r,3225,23)),Promise.resolve().then(r.t.bind(r,9295,23)),Promise.resolve().then(r.t.bind(r,3982,23))},917:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>a});var o=r(5344),n=r(3729),i=r(6046),s=r.n(i);let a=()=>{let[e,t]=(0,n.useState)(!1);return(0,n.useEffect)(()=>{let e=setInterval(()=>{t(e=>!e)},1e3);return()=>clearInterval(e)},[]),(0,o.jsxs)("div",{className:s().lightcontainer,children:[o.jsx("div",{className:s().light}),o.jsx("div",{className:s().light,style:{left:"unset",right:0}})]})}},9860:(e,t,r)=>{"use strict";r.d(t,{Z:()=>i});var o=r(5344),n=r(6506);let i=({children:e,to:t})=>o.jsx(n.default,{href:t,children:o.jsx("div",{className:"bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2",children:e})})},9666:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>l});var o=r(5344),n=r(6506),i=r(6974),s=r(29),a=r.n(s);let l=()=>(0,o.jsxs)("footer",{className:`${a().container} bg-gradient-to-b from-cards_bg to-transparent`,children:[o.jsx("div",{className:a().container__imgLogo,children:o.jsx(n.default,{href:"/",children:o.jsx("img",{src:i.default.src,alt:"Logo"})})}),o.jsx("div",{children:(0,o.jsxs)("fieldset",{className:a().container__form,children:[o.jsx("legend",{children:"Mis contactos"}),(0,o.jsxs)("ul",{children:[o.jsx("li",{children:"Email : nicoeloza12@gmail.com"}),o.jsx("li",{children:o.jsx(n.default,{href:"https://www.linkedin.com/in/nicoelozano/",target:"_blank",children:"Linkedin"})}),o.jsx("li",{children:o.jsx(n.default,{href:"https://github.com/nicolaselozano",target:"_blank",children:"Github"})})]})]})}),o.jsx("div",{children:o.jsx("button",{children:"Gracias por el espacio"})})]})},7429:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>g});var o=r(5344),n=r(3729),i=r(8529),s=r.n(i),a=r(9860),l=r(6813),c=r(2577);let d=()=>{let e=async()=>{localStorage.clear();let e=new l.ZP.WebAuth({domain:`${c.yK}`,clientID:`${c.Cx}`}).client.buildAuthorizeUrl({clientID:`${c.Cx}`,responseType:`${c.yO}`,redirectUri:`${c.He}/pages/redirect`,scope:`${c.IC}`,audience:`${c.u8}`});window.location.replace(e)};return o.jsx("button",{className:"bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2",onClick:e,children:"Login"})},u=()=>{let e=async()=>{localStorage.clear();let e=new l.ZP.WebAuth({domain:`${c.yK}`,clientID:`${c.Cx}`}).client.buildAuthorizeUrl({clientID:`${c.Cx}`,responseType:`${c.yO}`,redirectUri:`${c.He}/pages/redirect?signin=true`,scope:`${c.IC}`,audience:`${c.u8}`});window.location.replace(e)};return o.jsx("button",{className:"bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2",onClick:e,children:"Register"})};var h=r(4271),_=r.n(h);let x=()=>o.jsx("div",{children:(0,o.jsxs)("ul",{className:`flex ${_().list__button}`,children:[o.jsx("li",{className:`${_().container__button}`,children:o.jsx(a.Z,{to:"/",children:"Inicio"})}),o.jsx("li",{children:o.jsx(a.Z,{to:"/pages/proyects",children:"Proyectos"})}),o.jsx("li",{children:o.jsx(d,{})}),o.jsx("li",{children:o.jsx(u,{})})]})}),g=()=>{let[e,t]=(0,n.useState)(!1);return(0,o.jsxs)("div",{className:s().container,children:[o.jsx("div",{className:s().options_sreen,children:o.jsx(x,{})}),o.jsx("div",{className:s().menu_button,onClick:()=>{t(!e)},onMouseEnter:()=>{t(!0)},children:o.jsx("span",{})}),e?o.jsx("div",{className:s().modalContainer,onMouseLeave:()=>{t(!1)},children:o.jsx(x,{})}):null]})}},9768:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>a});var o=r(5344),n=r(8428),i=r(3729),s=r(9860);let a=()=>{let[e,t]=(0,i.useState)(),r=(0,n.usePathname)();return(0,i.useEffect)(()=>{let r=localStorage.getItem("user");null==e&&r&&t(JSON.parse(r))},[e?null:r]),o.jsx("div",{children:e?(0,o.jsxs)("div",{className:"flex-col items-center justify-center ml-5",children:[(0,o.jsxs)("h1",{children:["Bienvenido ",e?.name]}),o.jsx("div",{className:"ml-3 -mt-3",children:o.jsx(s.Z,{to:"/pages/Profile",children:"Perfil"})})]}):null})}},1021:(e,t,r)=>{"use strict";r.r(t),r.d(t,{ReduxProvider:()=>s});var o=r(5344),n=r(1531),i=r(6013);function s({children:e}){return o.jsx(i.zt,{store:n.h,children:e})}},1303:(e,t,r)=>{"use strict";r.d(t,{Gr:()=>n,K4:()=>i,ZP:()=>l,mc:()=>s,sT:()=>a});let o=(0,r(7627).oM)({name:"detail",initialState:{product:{},reviews:null,loading:!1,error:{}},reducers:{reset:()=>({product:{},loading:!1,error:{},reviews:null}),setProduct:(e,t)=>{e.product=t.payload.product,e.reviews=t.payload.reviews,e.loading=!1},setLoading:(e,t)=>{e.loading=t.payload},setError:(e,t)=>{e.error=t.payload}}}),{setProduct:n,setLoading:i,reset:s,setError:a}=o.actions,l=o.reducer},9006:(e,t,r)=>{"use strict";r.d(t,{DS:()=>i,Qt:()=>s,ZP:()=>c,gK:()=>n,mc:()=>l,sT:()=>a});let o=(0,r(7627).oM)({name:"Product",initialState:{MvotedProyect:{},allProduct:[],loading:!0,error:{}},reducers:{reset:()=>({MvotedProyect:{},allProduct:[],loading:!0,error:{}}),addProduct:(e,t)=>{e.allProduct=t.payload},setMvotedProyect:(e,t)=>{e.MvotedProyect=t.payload},setLoadingTrue:e=>{e.loading=!0,e.error={}},setLoadingFalse:e=>{e.loading=!1},setError:(e,t)=>{e.loading=!1,e.error=t.payload}}}),{addProduct:n,setLoadingTrue:i,setLoadingFalse:s,setError:a,reset:l}=o.actions,c=o.reducer},2634:(e,t,r)=>{"use strict";r.d(t,{K4:()=>n,ZP:()=>a,mc:()=>s,sT:()=>i});let o=(0,r(7627).oM)({name:"reviews",initialState:{loading:!1,error:{}},reducers:{reset:()=>({loading:!1,error:{}}),setError:(e,t)=>{e.error=t.payload,e.loading=!1},setLoading:(e,t)=>{e.loading=t.payload}}}),{setLoading:n,setError:i,reset:s}=o.actions,a=o.reducer},1531:(e,t,r)=>{"use strict";r.d(t,{C:()=>d,h:()=>c});var o=r(7627),n=r(9006),i=r(1303),s=r(2634),a=r(1455),l=r(6013);let c=(0,o.xC)({reducer:{productReducer:n.ZP,detailReducer:i.ZP,reviewReducer:s.ZP},middleware:e=>e().concat(a.I)}),d=l.v9},2577:(e,t,r)=>{"use strict";r.d(t,{Cx:()=>s,He:()=>l,IC:()=>i,QP:()=>c,u8:()=>o,yK:()=>n,yO:()=>a});let o="https://PORTAFOLIO_API.com",n="dev-v2roygalmy6qyix2.us.auth0.com",i="offline_access",s="FiGgFZqBNRTXMtroNlRxerrS9FEwWca8",a="code",l="https://proyectbox-au5d.onrender.com",c="https://proyectbox.onrender.com/api"},4070:e=>{e.exports={container:"globals_container__6OqUP"}},6046:e=>{e.exports={lightcontainer:"LightAnimation_lightcontainer__gjYRJ",light:"LightAnimation_light__x98n1",lightAnimation:"LightAnimation_lightAnimation__42mVA"}},29:e=>{e.exports={container:"Footer_container__Dj1D9",container__form:"Footer_container__form__LSKKV",container__imgLogo:"Footer_container__imgLogo__tHhCa"}},8529:e=>{e.exports={container:"DropMenu_container__aA_Zo",modalContainer:"DropMenu_modalContainer__ivj7Z",options_sreen:"DropMenu_options_sreen__vnyH6",menu_button:"DropMenu_menu_button__cYJmh",open:"DropMenu_open__UItSL"}},4075:e=>{e.exports={container:"NavBar_container__VY0s_",container_profile:"NavBar_container_profile__ErUGT",container__dropMenu:"NavBar_container__dropMenu__dMq0b",hide_mobile:"NavBar_hide_mobile__d1GFR"}},4271:e=>{e.exports={list__button:"NavOptions_list__button__p2JFa",container__button:"NavOptions_container__button__UddUs"}},3329:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>S,metadata:()=>C});var o=r(5036);r(2);var n=r(4075),i=r.n(n),s=r(6843);let a=(0,s.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\components\NavBar\DropMenu\DropMenu.tsx`),{__esModule:l,$$typeof:c}=a,d=a.default,u=(0,s.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\components\Profile\ProfileNav.tsx`),{__esModule:h,$$typeof:_}=u,x=u.default,g=()=>(0,o.jsxs)("nav",{className:`${i().container} bg-gradient-to-b from-cards_bg to-transparent`,children:[o.jsx("div",{className:`${i().container_profile}`,children:o.jsx(x,{})}),o.jsx("img",{className:"h-16",src:"/_next/static/media/OIG4.565f1274.webp",alt:"Logo My Proyects"}),o.jsx("div",{className:i().container__dropMenu,children:o.jsx(d,{})})]});r(1659);var p=r(4070),m=r.n(p);let v=(0,s.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\redux\Provider.tsx`),{__esModule:b,$$typeof:y}=v;v.default;let j=(0,s.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\redux\Provider.tsx#ReduxProvider`),f=(0,s.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\components\Animations\LightAnimation.tsx`),{__esModule:P,$$typeof:A}=f,w=f.default,N=(0,s.createProxy)(String.raw`D:\Proyectos\Portafolio (proyectos y arte)\client\src\components\Footer\Footer.tsx`),{__esModule:M,$$typeof:D}=N,$=N.default,C={title:"Create Next App",description:"Generated by create next app"},S=({children:e})=>(0,o.jsxs)("html",{lang:"en",children:[(0,o.jsxs)("head",{children:[o.jsx("meta",{charSet:"utf-8"}),o.jsx("meta",{name:"viewport",content:"width=device-width, initial-scale=1.0"}),o.jsx("link",{rel:"stylesheet",href:"../output.css"}),o.jsx("link",{rel:"stylesheet",href:"https://fonts.googleapis.com/css2?family=Inter:wght@400;500;700&display=swap"}),o.jsx("title",{children:"ProyectBox"}),o.jsx("meta",{name:"description",content:C.description})]}),(0,o.jsxs)("body",{className:"font-russo  text-white min-h-screen bg-gradient-to-b from-general_bg to-cards_bg ",children:[o.jsx(g,{}),(0,o.jsxs)("div",{className:m().container,children:[(0,o.jsxs)(j,{children:[e,o.jsx(w,{})]}),o.jsx($,{})]})]})]})},6974:(e,t,r)=>{"use strict";r.r(t),r.d(t,{default:()=>o});let o={src:"/_next/static/media/OIG4.565f1274.webp",height:1024,width:1024,blurDataURL:"data:image/webp;base64,UklGRpwAAABXRUJQVlA4WAoAAAAQAAAABwAABwAAQUxQSDcAAAABYBPbVqPrjIqKKphg0EDP5pyjgRWwCtEQEUlCdqcFTDs/0UMzDPcaILvff+lBb7L8HCDqS5EAAFZQOCA+AAAA0AEAnQEqCAAIAAJAOCWcNvj8HDeknWgA/vc0/8uf8hCjzv8qJ5j3y/5lWNITmNprgFqJu2wJpiwSWAA5gAA=",blurWidth:8,blurHeight:8}}};