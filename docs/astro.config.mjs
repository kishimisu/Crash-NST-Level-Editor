import { defineConfig } from 'astro/config';
import starlight from '@astrojs/starlight';
import starlightLinksValidator from 'starlight-links-validator';
import { satteri } from '@astrojs/markdown-satteri';

/**
 * Hosting location.
 *
 * Locally the site builds at the root ("/"). When deploying to GitHub project pages
 * the deploy workflow sets SITE and BASE from the repository name, e.g.
 *   SITE=https://<owner>.github.io BASE=/crash-nst-docs npm run build
 * DOCS_REPO_URL enables the "Edit this page" links (https://github.com/<owner>/<repo>).
 */
const SITE = process.env.SITE ?? 'https://kishimisu.github.io';
const BASE = process.env.BASE ?? '/';
const DOCS_REPO_URL = process.env.DOCS_REPO_URL;

/**
 * Sätteri mdast plugin: prefix root-relative links ("/play/...") with the Astro `base` path.
 * Content is written with plain absolute links; this keeps it working when the site is
 * served from a sub-path such as GitHub project pages. It runs on the Markdown AST, before
 * starlight-links-validator inspects the HTML, so validation sees the final URLs.
 */
function baseLinksPlugin() {
	const prefix = BASE.replace(/\/+$/, '');
	const withBase = (url) =>
		typeof url === 'string' && url.startsWith('/') && !url.startsWith('//') && !url.startsWith(`${prefix}/`)
			? prefix + url
			: url;
	// Sätteri nodes are read-only views: changes must go through ctx.replaceNode().
	const rewriteUrl = (node, ctx) => {
		const url = withBase(node.url);
		if (url !== node.url) ctx.replaceNode(node, { ...node, url });
	};
	const rewriteJsxAttributes = (node, ctx) => {
		let changed = false;
		const attributes = (node.attributes ?? []).map((attr) => {
			if (attr.type !== 'mdxJsxAttribute' || (attr.name !== 'href' && attr.name !== 'link') || typeof attr.value !== 'string') return attr;
			const value = withBase(attr.value);
			if (value === attr.value) return attr;
			changed = true;
			return { ...attr, value };
		});
		if (changed) ctx.replaceNode(node, { ...node, attributes });
	};
	return {
		name: 'base-links',
		link: rewriteUrl,
		definition: rewriteUrl,
		mdxJsxFlowElement: rewriteJsxAttributes,
		mdxJsxTextElement: rewriteJsxAttributes,
	};
}

// https://astro.build/config
export default defineConfig({
	site: SITE,
	base: BASE,
	// Dev server port, overridable with the PORT environment variable.
	server: { port: Number(process.env.PORT) || 4321 },
	markdown: {
		processor: satteri({ mdastPlugins: BASE === '/' ? [] : [baseLinksPlugin()] }),
	},
	integrations: [
		starlight({
			title: 'Crash NST Maker',
			description:
				'Documentation for Crash NST Maker: create, play and share custom levels for Crash Bandicoot N. Sane Trilogy, and explore the game files.',
			logo: { src: './src/assets/logo.svg', alt: 'Crash NST Maker' },
			favicon: '/src/assets/favicon.svg',
			locales: { root: { label: 'English', lang: 'en' } },
			social: [
				{ icon: 'github', label: 'GitHub', href: 'https://github.com/kishimisu/Crash-NST-Level-Editor' },
			],
			editLink: DOCS_REPO_URL ? { baseUrl: `${DOCS_REPO_URL.replace(/\/+$/, '')}/edit/main/docs/` } : undefined,
			lastUpdated: true,
			customCss: ['./src/styles/custom.css'],
			head: [
				{
					// allow images to be enlarged
					tag: 'script',
					content: `
						document.addEventListener('click', (event) => {
							const target = event.target;

							if (!(target instanceof HTMLImageElement)) return;
							if (!target.closest('.sl-markdown-content')) return;
							if (target.closest('a')) return;

							const overlay = document.createElement('div');
							overlay.className = 'image-overlay';

							const image = document.createElement('img');
							image.src = target.currentSrc || target.src;
							image.alt = target.alt;

							overlay.appendChild(image);
							document.body.appendChild(overlay);

							overlay.addEventListener('click', () => {
								overlay.remove();
							});
						});
					`,
				},
			],
			sidebar: [
				{ label: 'Get Started', items: [{ autogenerate: { directory: 'get-started' } }] },
				{
					label: 'Level Editor',
					items: [
						'level-editor/overview',
						'level-editor/create-a-new-level',
						'level-editor/level-settings',
						'level-editor/editor-settings',
						'level-editor/navigate-the-scene',
						'level-editor/transform-and-gizmos',
						'level-editor/quick-access-menu',
						'level-editor/object-library',
						'level-editor/object-tree-and-camera-layers',
						'level-editor/object-properties',
						'level-editor/undo-and-backups',
						'level-editor/play-save-export',
						'level-editor/custom-hubs-and-modpacks',
						'level-editor/ctr-nf-support',
						'level-editor/export-to-gltf',
						'level-editor/troubleshooting',
						{
							label: 'Special Objects',
							collapsed: true,
							items: [{ autogenerate: { directory: 'level-editor/special-objects' } }],
						},
						{
							label: 'Special Components',
							collapsed: true,
							items: [{ autogenerate: { directory: 'level-editor/special-components' } }],
						},
					],
				},
				{ label: 'Archive Editor', collapsed: true, items: [{ autogenerate: { directory: 'archive-editor' } }] },
				{ label: 'Reference', items: [{ autogenerate: { directory: 'reference' } }] },
			],
			// Content links are absolute ("/play/...") and validated. Relative links are not validated:
			// the only intended one is the hero action in index.mdx, which lives in frontmatter and so
			// cannot be prefixed with `base` by baseLinksPlugin.
			plugins: [starlightLinksValidator({ errorOnRelativeLinks: false })],
		}),
	],
});
