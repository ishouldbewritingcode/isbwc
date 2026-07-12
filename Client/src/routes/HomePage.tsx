import { useSiteQuery } from "../api/queries";

export function HomePage() {
	const { data: site } = useSiteQuery();

	return <div>{site?.subTitle && <p>{site.subTitle}</p>}</div>;
}
