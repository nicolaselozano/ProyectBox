(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[185],{1473:function(e,n,t){Promise.resolve().then(t.bind(t,6438)),Promise.resolve().then(t.t.bind(t,8693,23)),Promise.resolve().then(t.t.bind(t,6414,23)),Promise.resolve().then(t.bind(t,3871)),Promise.resolve().then(t.bind(t,5499)),Promise.resolve().then(t.bind(t,2204)),Promise.resolve().then(t.t.bind(t,9790,23)),Promise.resolve().then(t.bind(t,8450)),Promise.resolve().then(t.bind(t,2277))},7907:function(e,n,t){"use strict";var r=t(5313);t.o(r,"usePathname")&&t.d(n,{usePathname:function(){return r.usePathname}}),t.o(r,"useSearchParams")&&t.d(n,{useSearchParams:function(){return r.useSearchParams}})},3871:function(e,n,t){"use strict";t.r(n);var r=t(3827),o=t(4090),i=t(9583),c=t.n(i);n.default=()=>{let[e,n]=(0,o.useState)(!1);return(0,o.useEffect)(()=>{let e=setInterval(()=>{n(e=>!e)},1e3);return()=>clearInterval(e)},[]),(0,r.jsxs)("div",{className:c().lightcontainer,children:[(0,r.jsx)("div",{className:c().light}),(0,r.jsx)("div",{className:c().light,style:{left:"unset",right:0}})]})}},7997:function(e,n,t){"use strict";var r=t(3827),o=t(8792);n.Z=e=>{let{children:n,to:t}=e;return(0,r.jsx)(o.default,{href:t,children:(0,r.jsx)("div",{className:"bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2",children:n})})}},5499:function(e,n,t){"use strict";t.r(n);var r=t(3827),o=t(8792),i=t(6438),c=t(9799),a=t.n(c);n.default=()=>(0,r.jsxs)("footer",{className:"".concat(a().container," bg-gradient-to-b from-cards_bg to-transparent"),children:[(0,r.jsx)("div",{className:a().container__imgLogo,children:(0,r.jsx)(o.default,{href:"/",children:(0,r.jsx)("img",{src:i.default.src,alt:"Logo"})})}),(0,r.jsx)("div",{children:(0,r.jsxs)("fieldset",{className:a().container__form,children:[(0,r.jsx)("legend",{children:"Mis contactos"}),(0,r.jsxs)("ul",{children:[(0,r.jsx)("li",{children:"Email : nicoeloza12@gmail.com"}),(0,r.jsx)("li",{children:(0,r.jsx)(o.default,{href:"https://www.linkedin.com/in/nicoelozano/",target:"_blank",children:"Linkedin"})}),(0,r.jsx)("li",{children:(0,r.jsx)(o.default,{href:"https://github.com/nicolaselozano",target:"_blank",children:"Github"})})]})]})}),(0,r.jsx)("div",{children:(0,r.jsx)("button",{children:"Gracias por el espacio"})})]})},2204:function(e,n,t){"use strict";t.r(n),t.d(n,{default:function(){return g}});var r=t(3827),o=t(4090),i=t(7605),c=t.n(i),a=t(7997),s=t(6830),l=t(8021),u=()=>{let e=async()=>{localStorage.clear();let e=new s.ZP.WebAuth({domain:"".concat(l.yK),clientID:"".concat(l.Cx)}).client.buildAuthorizeUrl({clientID:"".concat(l.Cx),responseType:"".concat(l.yO),redirectUri:"".concat(l.He,"/pages/redirect"),scope:"".concat(l.IC),audience:"".concat(l.u8)});window.location.replace(e)};return(0,r.jsx)("button",{className:"bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2",onClick:e,children:"Login"})},d=()=>{let e=async()=>{localStorage.clear();let e=new s.ZP.WebAuth({domain:"".concat(l.yK),clientID:"".concat(l.Cx)}).client.buildAuthorizeUrl({clientID:"".concat(l.Cx),responseType:"".concat(l.yO),redirectUri:"".concat(l.He,"/pages/redirect?signin=true"),scope:"".concat(l.IC),audience:"".concat(l.u8)});window.location.replace(e)};return(0,r.jsx)("button",{className:"bg- hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2",onClick:e,children:"Register"})},_=t(2989),h=t.n(_),f=()=>(0,r.jsx)("div",{children:(0,r.jsxs)("ul",{className:"flex ".concat(h().list__button),children:[(0,r.jsx)("li",{className:"".concat(h().container__button),children:(0,r.jsx)(a.Z,{to:"/",children:"Inicio"})}),(0,r.jsx)("li",{children:(0,r.jsx)(a.Z,{to:"/pages/proyects",children:"Proyectos"})}),(0,r.jsx)("li",{children:(0,r.jsx)(u,{})}),(0,r.jsx)("li",{children:(0,r.jsx)(d,{})})]})}),g=()=>{let[e,n]=(0,o.useState)(!1);return(0,r.jsxs)("div",{className:c().container,children:[(0,r.jsx)("div",{className:c().options_sreen,children:(0,r.jsx)(f,{})}),(0,r.jsx)("div",{className:c().menu_button,onClick:()=>{n(!e)},onMouseEnter:()=>{n(!0)},children:(0,r.jsx)("span",{})}),e?(0,r.jsx)("div",{className:c().modalContainer,onMouseLeave:()=>{n(!1)},children:(0,r.jsx)(f,{})}):null]})}},8450:function(e,n,t){"use strict";t.r(n);var r=t(3827),o=t(7907),i=t(4090),c=t(7997);n.default=()=>{let[e,n]=(0,i.useState)(),t=(0,o.usePathname)();return(0,i.useEffect)(()=>{let t=localStorage.getItem("user");null==e&&t&&n(JSON.parse(t))},[e?null:t]),(0,r.jsx)("div",{children:e?(0,r.jsxs)("div",{className:"flex-col items-center justify-center ml-5",children:[(0,r.jsxs)("h1",{children:["Bienvenido ",null==e?void 0:e.name]}),(0,r.jsx)("div",{className:"ml-3 -mt-3",children:(0,r.jsx)(c.Z,{to:"/pages/Profile",children:"Perfil"})})]}):null})}},2277:function(e,n,t){"use strict";t.r(n),t.d(n,{ReduxProvider:function(){return c}});var r=t(3827),o=t(5196),i=t(828);function c(e){let{children:n}=e;return(0,r.jsx)(i.zt,{store:o.h,children:n})}},3724:function(e,n,t){"use strict";t.d(n,{Gr:function(){return o},K4:function(){return i},mc:function(){return c},sT:function(){return a}});let r=(0,t(1530).oM)({name:"detail",initialState:{product:{},reviews:null,loading:!1,error:{}},reducers:{reset:()=>({product:{},loading:!1,error:{},reviews:null}),setProduct:(e,n)=>{e.product=n.payload.product,e.reviews=n.payload.reviews,e.loading=!1},setLoading:(e,n)=>{e.loading=n.payload},setError:(e,n)=>{e.error=n.payload}}}),{setProduct:o,setLoading:i,reset:c,setError:a}=r.actions;n.ZP=r.reducer},8816:function(e,n,t){"use strict";t.d(n,{DS:function(){return i},Qt:function(){return c},gK:function(){return o},mc:function(){return s},sT:function(){return a}});let r=(0,t(1530).oM)({name:"Product",initialState:{MvotedProyect:{},allProduct:[],loading:!0,error:{}},reducers:{reset:()=>({MvotedProyect:{},allProduct:[],loading:!0,error:{}}),addProduct:(e,n)=>{e.allProduct=n.payload},setMvotedProyect:(e,n)=>{e.MvotedProyect=n.payload},setLoadingTrue:e=>{e.loading=!0,e.error={}},setLoadingFalse:e=>{e.loading=!1},setError:(e,n)=>{e.loading=!1,e.error=n.payload}}}),{addProduct:o,setLoadingTrue:i,setLoadingFalse:c,setError:a,reset:s}=r.actions;n.ZP=r.reducer},2063:function(e,n,t){"use strict";t.d(n,{K4:function(){return o},mc:function(){return c},sT:function(){return i}});let r=(0,t(1530).oM)({name:"reviews",initialState:{loading:!1,error:{}},reducers:{reset:()=>({loading:!1,error:{}}),setError:(e,n)=>{e.error=n.payload,e.loading=!1},setLoading:(e,n)=>{e.loading=n.payload}}}),{setLoading:o,setError:i,reset:c}=r.actions;n.ZP=r.reducer},5196:function(e,n,t){"use strict";t.d(n,{C:function(){return u},h:function(){return l}});var r=t(1530),o=t(8816),i=t(3724),c=t(2063),a=t(687),s=t(828);let l=(0,r.xC)({reducer:{productReducer:o.ZP,detailReducer:i.ZP,reviewReducer:c.ZP},middleware:e=>e().concat(a.I)}),u=s.v9},8021:function(e,n,t){"use strict";t.d(n,{Cx:function(){return c},He:function(){return s},IC:function(){return i},QP:function(){return l},u8:function(){return r},yK:function(){return o},yO:function(){return a}});let r="https://PORTAFOLIO_API.com",o="dev-v2roygalmy6qyix2.us.auth0.com",i="offline_access",c="FiGgFZqBNRTXMtroNlRxerrS9FEwWca8",a="code",s="https://proyectbox-au5d.onrender.com",l="https://proyectbox.onrender.com/api"},6414:function(){},8693:function(e){e.exports={container:"globals_container__6OqUP"}},9583:function(e){e.exports={lightcontainer:"LightAnimation_lightcontainer__gjYRJ",light:"LightAnimation_light__x98n1",lightAnimation:"LightAnimation_lightAnimation__42mVA"}},9799:function(e){e.exports={container:"Footer_container__Dj1D9",container__form:"Footer_container__form__LSKKV",container__imgLogo:"Footer_container__imgLogo__tHhCa"}},7605:function(e){e.exports={container:"DropMenu_container__aA_Zo",modalContainer:"DropMenu_modalContainer__ivj7Z",options_sreen:"DropMenu_options_sreen__vnyH6",menu_button:"DropMenu_menu_button__cYJmh",open:"DropMenu_open__UItSL"}},9790:function(e){e.exports={container:"NavBar_container__VY0s_",container_profile:"NavBar_container_profile__ErUGT",container__dropMenu:"NavBar_container__dropMenu__dMq0b",hide_mobile:"NavBar_hide_mobile__d1GFR"}},2989:function(e){e.exports={list__button:"NavOptions_list__button__p2JFa",container__button:"NavOptions_container__button__UddUs"}},6438:function(e,n,t){"use strict";t.r(n),n.default={src:"/_next/static/media/OIG4.565f1274.webp",height:1024,width:1024,blurDataURL:"data:image/webp;base64,UklGRpwAAABXRUJQVlA4WAoAAAAQAAAABwAABwAAQUxQSDcAAAABYBPbVqPrjIqKKphg0EDP5pyjgRWwCtEQEUlCdqcFTDs/0UMzDPcaILvff+lBb7L8HCDqS5EAAFZQOCA+AAAA0AEAnQEqCAAIAAJAOCWcNvj8HDeknWgA/vc0/8uf8hCjzv8qJ5j3y/5lWNITmNprgFqJu2wJpiwSWAA5gAA=",blurWidth:8,blurHeight:8}}},function(e){e.O(0,[369,477,792,895,971,69,744],function(){return e(e.s=1473)}),_N_E=e.O()}]);