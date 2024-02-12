import Link from "next/link";

interface Label {

    children:React.ReactNode,
    to:string
}

const Button_Nav:React.FC<Label> = ({children,to}:Label) => {

    return (

        <Link href={to}>
            <div className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
            {children}
            </div>
        </Link>
    )

}

export default Button_Nav;