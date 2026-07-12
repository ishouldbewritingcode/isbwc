import { Outlet } from "react-router-dom";
import { useNavQuery, useSiteQuery } from "../api/queries";
import { NavList } from "./NavList";

export function RootLayout() {
	const site = useSiteQuery();
	const nav = useNavQuery();

	if (site.isLoading || nav.isLoading) {
		return <p>Loading...</p>;
	}

	if (site.isError || nav.isError) {
		return <p>Something went wrong loading the site.</p>;
	}

	return (
		<>
			<header>
				<h1>{site.data?.title}</h1>
				<nav>
					<NavList items={nav.data ?? []} />
				</nav>
			</header>
			<main>
				<Outlet />
			</main>
			<footer>
				<p>{site.data?.footer1}</p>
			</footer>
		</>
	);
}
