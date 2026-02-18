# Flowers — Wireframe Reference

> **Source:** Figma Make file "Flowers - Wireframes (Copy)"
> **Captured:** 2026-02-17
> **Purpose:** Legacy gift scheduling platform wireframes for development reference

## What is Flowers?

**Flowers** is a legacy gift scheduling platform that allows people to plan and pre-pay for gifts (flowers, letters, video messages, keepsakes) to be delivered to loved ones after they pass away. The service uses a trusted executor system to activate deliveries.

## Site Structure (7 pages)

| # | Page | Route | Description |
|---|------|-------|-------------|
| 1 | **Homepage** | `/` | Landing page with hero, how-it-works, packages, testimonials, trust signals |
| 2 | **How It Works** | `/how-it-works` | Detailed 4-step process with feature highlights |
| 3 | **Legacy Gifts** | `/gifts` | Product catalog with 9 packages + filter tabs + custom builder |
| 4 | **Stories** | `/stories` | 6 long-form customer stories |
| 5 | **FAQ** | `/faq` | 20 questions across 5 categories (accordion) |
| 6 | **About** | `/about` | Origin story, values, mission, team (4 members) |
| 7 | **Contact** | `/contact` | Contact info + form + live chat |

## Key Features

- **Executor System:** Users designate a trusted person (family, lawyer, or professional) to activate deliveries
- **Pre-funded Accounts:** One-time payments ensure guaranteed fulfillment
- **Flexible Scheduling:** Deliveries up to 50 years in advance
- **Multi-format Content:** Flowers, handwritten letters, video messages, keepsakes, photos
- **AES-256 Encryption:** Military-grade security for stored messages

## Gift Packages (from wireframes)

| Package | Deliveries | Price | Type |
|---------|-----------|-------|------|
| Eternal Love Package | 10 | $499.99 | Anniversary roses, 10 years |
| Birthday Sunshine | 5 | $299.99 | Birthday sunflowers |
| Comfort & Grace | 12 | $599.99 | Monthly bouquets, first year |
| Wildflower Memories | 8 | $449.99 | Seasonal bouquets + letters |
| Forever Romance | 15 | $749.99 | Valentine's roses, 15 years |
| Garden of Remembrance | 20 | $399.99 | Quarterly + photo cards |
| Handwritten Letters | — | — | 12 letters for occasions |
| Video Message Package | — | — | 6 milestone videos |
| Wisdom Journal | — | — | Advice letters, 10 years |
| Memory Keepsake Box | — | — | Physical items quarterly |
| Complete Legacy Suite | — | — | Everything for 20 years |

## Team (fictional)

- **Emily Chen** — Founder & CEO
- **David Martinez** — CTO (cybersecurity background)
- **Sarah Thompson** — Director of Legacy Planning (grief counselor)
- **James Wilson** — Head of Fulfillment (luxury concierge)

## Design Notes

- **Color palette:** Deep navy/indigo primary, purple accents, white/light gray backgrounds
- **Typography:** Serif headings (editorial feel), sans-serif body
- **Style:** Clean, elegant, compassionate — appropriate for the sensitive subject matter
- **Layout:** Standard marketing site with sticky nav, section-based scrolling pages
- **Images:** Flower photography throughout (roses, sunflowers, tulips, wildflowers)

## Files

- `sitemap.md` — Complete text content extraction with UI hierarchy for every page
- `slide-01-home-*.png` — Homepage screenshots (6 viewport captures)
- `slide-02-how-it-works-*.png` — How It Works page (2 captures)
- `slide-03-legacy-gifts-top.png` — Legacy Gifts catalog page
- `slide-04-stories-top.png` — Stories page
- `slide-05-faq-top.png` — FAQ page
- `slide-06-about-top.png` — About page
- `slide-07-contact-top.png` — Contact page

## For Claude / Development

The `sitemap.md` file contains the **complete text content** for every page, organized by section with heading hierarchy. Use it as a source of truth for:
- Page content and copy
- Navigation structure and routing
- Component inventory (cards, forms, accordions, CTAs)
- Data models (packages, testimonials, FAQ items, team members)
