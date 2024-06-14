"use client"
import CDetail from "@/components/Details/Detail";
import { UUID } from "crypto";
import { useSearchParams } from "next/navigation";
import { Suspense } from "react";

const DetailParamsPage = () => {

    const searchParams = useSearchParams();
    const id = searchParams.get("id");
    
  return (
    <div>
      <CDetail id={`${id as UUID}`} />
    </div>
  );
};

export default function Detail() {
  return (
    <Suspense fallback={<div>Loading...</div>}>
      <DetailParamsPage />
    </Suspense>
  );
}

