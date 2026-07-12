import type { NavItem } from '../api/types';

export function NavList({ items }: { items: NavItem[] }) {
  if (items.length === 0) {
    return null;
  }

  return (
    <ul>
      {items.map((item) => (
        <li key={item.pageId}>
          {item.navTitle ?? item.title}
          {item.children.length > 0 && <NavList items={item.children} />}
        </li>
      ))}
    </ul>
  );
}
