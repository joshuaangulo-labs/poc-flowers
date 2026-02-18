# Flowers — Authenticated Pages Sitemap

> Extracted from Figma wireframe screenshots on 2026-02-17

---

## 1. Login (`/account/login`)
**Screenshot:** `auth-login-01.png`

### Header
- Flowers (logo)

### Content
- **Welcome Back**
- Sign in to manage your legacy gifts

### Form
- **Email** — placeholder: you@example.com
- **Password** — placeholder: ••••••••
- ☐ Remember me
- Forgot password? (link)
- **Sign In** (button)
- Don't have an account? **Sign up** (link)

### Footer
- By continuing, you agree to our **Terms of Service** and **Privacy Policy**

---

## 2. Dashboard (`/account/dashboard`)
**Screenshots:** `auth-dashboard-01.png`, `auth-dashboard-02.png`, `auth-dashboard-fullscreen-01.png`

### Top Nav
- ← Back to Site | **Flowers**
- **Sarah Johnson** — Member since 2024 — (logout)

### Sidebar Navigation
- Dashboard (active)
- Schedule New Gift
- My Scheduled Gifts
- Received Gifts
- Settings

### Bottom Nav (mobile)
- Dashboard | Schedule | My | Received

### Welcome
- **Welcome Back, Sarah**
- Manage your legacy gifts and ensure your love lives on

### Stats Cards (row of 4)
| Stat | Value |
|------|-------|
| 🎁 Scheduled Gifts | **12** |
| 📅 Next Delivery | **Mar 15** |
| ❤️ Recipients | **5** |
| 📈 Total Spent | **$1,249** |

### Upcoming Deliveries
- **Emma Johnson** · Birthday — **Edit**
  - Pink Rose Elegance + Letter
  - 📅 March 14, 2026
- **Michael Johnson** · Graduation — **Edit**
  - Sunflower Delight + Video Message
  - 📅 May 19, 2026
- **Emma Johnson** · Anniversary — **Edit**
  - Red Roses + Handwritten Letter
  - 📅 June 9, 2026

### Quick Actions
- 🎁 **Schedule New Gift** (primary)
- ❤️ **View All Gifts**
- 🕐 **Manage Executors**

### Recent Activity
- Created new gift delivery — Emma Johnson — 2/4/2026
- Updated delivery message — Michael Johnson

---

## 3. Schedule New Gift (`/account/schedule`)
**Screenshot:** `auth-schedule-01.png`

### Progress Stepper
1. **Recipient** (active)
2. Gift
3. Message
4. Review

### Page Header
- **Schedule a New Gift**
- Create a meaningful delivery for your loved ones

### Step 1: Recipient Form
- **Recipient Name** * — placeholder: Enter recipient's name
- **Occasion** * — dropdown: Select an occasion
- **Delivery Date** * — mm/dd/yyyy (calendar picker)
  - Note: "This gift will only be delivered after your passing, on the date specified"

### Actions
- **Continue to Gift Selection >** (button)

---

## 4. My Scheduled Gifts (`/account/my-gifts`)
**Screenshots:** `auth-my-gifts-01.png`, `auth-my-gifts-02.png`, `auth-my-gifts-03.png`

### Page Header
- **My Scheduled Gifts**
- Manage all your planned legacy deliveries

### Stats
| Stat | Value |
|------|-------|
| Total Scheduled | **8** |
| Next Delivery | **Mar 14** |
| Total Investment | **$374.92** |

### Filter Tabs
- **All Gifts (8)** (active) | Next 12 Months | Future

### Gift Cards (8 total)

| # | Gift | Recipient | Occasion | Date | Location | Price |
|---|------|-----------|----------|------|----------|-------|
| 1 | Pink Rose Elegance | Emma Johnson | Birthday | Mar 14, 2026 | 123 Main St, Boston, MA | $45.99 |
| 2 | Sunflower Delight | Michael Johnson | Graduation | May 19, 2026 | 456 College Ave, Cambridge, MA | $38.99 |
| 3 | Red Rose Romance | Emma Johnson | Wedding Anniversary | Jun 9, 2026 | 123 Main St, Boston, MA | $49.99 |
| 4 | Winter Wonderland Bouquet | Sarah Wilson | Christmas | Dec 24, 2026 | 321 Pine St, Seattle, WA | $55.99 |
| 5 | Pink Rose Elegance | Emma Johnson | Mother's Day | May 8, 2027 | 123 Main St, Boston, MA | $45.99 |
| 6 | White Tulip Grace | David Martinez | Father's Day | Jun 19, 2027 | 789 Oak Rd, Portland, OR | $52.99 |
| 7 | Sunflower Delight | Michael Johnson | Birthday | Aug 11, 2027 | 456 College Ave, Cambridge, MA | $38.99 |
| 8 | Pink Rose Elegance | Emma Johnson | Birthday | Mar 14, 2028 | 123 Main St, Boston, MA | — |

### Each Card Shows
- Gift name + Recipient
- Occasion badge
- Delivery date
- Delivery address
- Message preview (truncated)
- "Scheduled" status badge
- Price
- **Edit** | **Delete** buttons

### Sample Messages
1. "Happy birthday my darling daughter. I hope these roses brighten your special day..."
2. "Congratulations on your graduation! I am so proud of the man you have become..."
3. "Happy anniversary to you and Tom. May your love continue to grow..."
4. "Merry Christmas dear sister. May your holidays be filled with love and joy..."
5. "To my daughter on her first Mother's Day. You will be an amazing mom..."
6. "Happy Father's Day to the best brother and father. Love you always..."
7. "Another year older and wiser. Keep chasing your dreams, son..."
8. "Happy birthday sweetheart! Another year of your beautiful life to celebrate..."

---

## 5. Received Gifts (`/account/received`)
**Screenshots:** `auth-received-01.png`, `auth-received-02.png`, `auth-received-03.png`

### Page Header
- **Gifts Received**
- Treasured messages and gifts from loved ones who are always with you

### Summary Banner
- ❤️ **3 Gifts Received**
- Each one a reminder that love never ends

### Gift Card 1 — Birthday from Mom
- Received on March 14, 2025
- Pink Rose Elegance
- **Personal Message:** "My dearest Emma, Happy 28th birthday! I hope these roses bring a smile to your face and warmth to your heart. Remember that I am always with you, cheering you on in everything you do. You have grown into such a beautiful, strong, and compassionate woman. I am so incredibly proud of you. Keep shining your light on the world. All my love, forever and always. Mom"
- 🖼 View Photos

### Gift Card 2 — Graduation from Dad
- Received on May 19, 2024
- Sunflower Delight
- **Personal Message:** "Emma, Congratulations on graduating! This is such a huge accomplishment, and I wish I could be there to see you walk across that stage. These sunflowers remind me of you - always bright, always reaching toward the light. Your future is limitless, and I know you'll achieve amazing things. Remember: be kind, work hard, and never stop learning. I love you so much. Dad"
- 🎬 Watch Video

### Gift Card 3 — Christmas from Mom
- Received on December 24, 2024
- White Tulip Grace
- **Personal Message:** "Merry Christmas my sweet girl! I hope your day is filled with joy, laughter, and all the magic of the season. These white tulips symbolize peace and new beginnings - may this year bring you both. I'm wrapping you in a big hug from heaven. Enjoy every moment with the people you love. Mom"
- 🖼 View Photos

### About Section
- **About Received Gifts** — These gifts were lovingly planned and scheduled by someone special before they passed away. Each delivery is a testament to their enduring love and their desire to remain present in your life's important moments. You can view all messages, photos, and videos anytime.

---

## 6. Settings (`/account/settings`)
**Note:** Settings screenshots were captured but text extraction pending. Based on sub-agent report:

### Profile Section
- Profile information editing

### Trusted Executors
- Primary executor + Backup executor
- (People designated to activate deliveries after passing)

### Security
- Password change
- Two-factor authentication (2FA)

### Notifications
- 3 notification toggles

### Danger Zone
- Pause account
- Delete account
