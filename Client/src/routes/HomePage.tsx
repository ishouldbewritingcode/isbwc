import { useSiteQuery } from '../api/queries';

export function HomePage() {
  const { data: site } = useSiteQuery();

  return (
    <div>
      <h1>{site?.title ?? 'Welcome'}</h1>
      {site?.subTitle && <p>{site.subTitle}</p>}
    </div>
  );
}
