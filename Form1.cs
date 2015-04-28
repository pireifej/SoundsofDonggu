using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SoundsofDonggu {
    public partial class Sounds_of_Donggu : Form {
        // global objects
        WMPLib.WindowsMediaPlayer my_player = new WMPLib.WindowsMediaPlayer();
        FileInfo my_file = new FileInfo("init");
        Random random = new Random();

        // constants
        String n = @"\par";
        int max_page = 4;

        // prompt names
        String d = "Dongyu";
        String p = "Paul";
        String t = "TV Commercial";
        String s = "Siri";

        // persistent state tracking
        Boolean is_playing = false;
        int current_page = 1;

        public Sounds_of_Donggu() {
            InitializeComponent();
        }

        // text manipulation

        private void set_text(String text) {
            rtb_dialog.Rtf = text;
        }

        private String prompt(String text) {
            return (@"\b " + text + @": \b0");
        }

        private String dialog(String text) {
            return (text + n);
        }

        private void set_image(Object image_resource) {
            pbx_image.BackgroundImage = (System.Drawing.Image)image_resource;
        }

        private void set_play() {
            btn_pause.Image = Properties.Resources.pause;
            is_playing = true;
        }

        private void set_pause() {
            btn_pause.Image = Properties.Resources.play;
            is_playing = false;
        }

        // audio manipulation

        private void play_song(byte[] song_bytes) {
            my_file.Delete();
            int random_number = random.Next(0, 1000);
            my_file = new FileInfo(random_number.ToString() + ".wma");
            FileStream fs = my_file.OpenWrite();
            fs.Write(song_bytes, 0, song_bytes.Length);
            fs.Close();
            my_player.URL = my_file.Name;
            my_player.controls.play();
        }

        private void button1_Click(object sender, EventArgs e) {
            my_player.controls.stop();
            set_pause();
        }

        private void btn_pause_Click(object sender, EventArgs e) {
            if (is_playing) {
                my_player.controls.pause();
                set_pause();
            } else {
                my_player.controls.play();
                set_play();
            }
        }

        private void btn_test_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.baby_baby_baby_oh);
            set_image(Properties.Resources.dongyu_silly);
            set_text(@"{\rtf1\ansi " + prompt("Dongyu") + " Oh baby baby ah la la oh ah.}");
        }

        private void btn_bless_you_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.bless_you);
            set_image(Properties.Resources.paul_dongyu_smile);
            set_text(@"{\rtf1\ansi " + 
                    prompt(d) + " Oh, your boogers." + n +
                    prompt(p) + "Help you wipe what?" + n +
                    prompt(d) + "Your boogers that you put on meeeeeeee." + n +
                    prompt(p) + "Where did I put the boogers?" + n +
                    prompt(d) + "I don't..." + n +
                    prompt(p) + "I can do it." + n +
                    prompt(p) + "Honey, I have to sneeze." + n + 
                    prompt(d) + "White, yellow and green." +n + 
                    prompt(p) + "<sneeze>" + n + 
                    prompt(d) + "Oh bless yoooooooooooooouuuuu." + n + 
                    prompt(p) + "Thank you.}"
            );
        }

        private void btn_chinese_singing_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.chinese_singing);
            set_image(Properties.Resources.donggu);
            set_text(@"{\rtf1\ansi " + 
                prompt(d) + dialog("<Chinese singing>}")
            );
        }

        private void btn_commercial_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.commercial);
            set_image(Properties.Resources.donggu_silly);
            set_text(@"{\rtf1\ansi " +
                prompt(t) + "... finding what direction I wanted my life to go in ..." + n +
                prompt(d) + "What direction I want my life be going." + n +
                prompt(t) + "... around america ... we started building houses ..." + n +
                prompt(d) + "Noo, we know that you stupid." + n +
                prompt(t) + "... new houses ..." + n +
                prompt(d) + "You want come?" + n +
                prompt(t) + "... far more rewarding than any amount of money or any material posession I could ever have ..." + n +
                prompt(d) + "Ooh really - how did that happen?}"
            );
        }

        private void btn_conversation_with_God_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.conversation_with_God);
            set_image(Properties.Resources.god);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + "Ooh." + n +
                prompt(p) + "So you have to Google everything?" + n +
                prompt(d) + "Exactly!" + n +
                prompt(p) + "God, do you love me?" + n +
                prompt(d) + "Oh, I love everybody who believe in me." + n +
                prompt(p) + "So then who do you love the most between me and Dongyu?" + n +
                prompt(d) + "Oh, Dongyu doesn't believe in me." + n +
                prompt(p) + "Why not? Does that mean that she's going to hell, God?" + n +
                prompt(d) + "Yes." + n +
                prompt(p) + "So then Dongyu is going to hell?" + n +
                prompt(d) + "Yes." + n +
                prompt(p) + "Is there anything that I can do to make sure she goes to Heaven?" + n +
                prompt(d) + "Oh, there's nothing you can do." + n +
                prompt(p) + "So my wife is going to hell?" + n +
                prompt(d) + "Yes." + n +
                prompt(p) + "How about me, Father? Where am I going?" + n +
                prompt(d) + "Where you going depends on what you doing." + n +
                prompt(p) + "On, what - I don't understand? Is this a..." + n +
                prompt(d) + "If you don't call your father, you will go to hell." + n +
                prompt(p) + "Oooooooooooooh." + n +
                prompt(p) + "God, do I really have to go to Church every Sunday?" + n +
                prompt(d) + "Well, ask your heart." + n +
                prompt(p) + "Ask my heart?" + n +
                prompt(d) + "Yes." + n +
                prompt(p) + "God, why did you create us human beings?" + n +
                prompt(d) + "I don't create you guys." + n +
                prompt(p) + "So then who created us, God?" + n +
                prompt(d) + "You thought I created." + n +
                prompt(p) + "Oh, I didn't think that you were done because that sentence wasn't complete." + n +
                prompt(d) + "You guys.... you human being." + n +
                prompt(p) + "So then who created us, God?" + n +
                prompt(d) + "You human being evolution." + n +
                prompt(p) + "What did we evolve from?" + n +
                prompt(d) + "Monkey." + n +
                prompt(p) + "And then who created the monkey.. s." + n +
                prompt(d) + "Oh, they evolu.. evolved from from from from from some other creator." + n +
                prompt(p) + "Oh, so then you have a brother? And he created us? God?" + n +
                prompt(d) + "Creature - your English sucks." + n +
                prompt(p) + "God, can I - if I pray for chocolate cake, will you give me a cake?" + n +
                prompt(d) + "Son, cake is not good for your teeth." + n +
                prompt(p) + "Well, tell that to my wife. She has a cavitiy on her front teeth." + n +
                prompt(d) + "Well, you should take care of her." + n +
                prompt(p) + "Like how? I don't have any money?" + n +
                prompt(d) + "Oh, you don't?" + n +
                prompt(p) + "God? Can you give me money, God?" + n +
                prompt(d) + "I'm not going to talk to you. That means you don't have money to contribute to me every Sunday." + n +
                prompt(p) + "Oh, so you don't - you don't talk to poor people, God?" + n +
                prompt(d) + "Right." + n +
                prompt(p) + "Oh, God, I'll pray to you every morning to give me money." + n +
                prompt(d) + "I don't give you money. You give me money." + n +
                prompt(p) + "God, you're being kind of rude right now. Are you drinking tea, God? God, what is your favorite iPad app?" + n +
                prompt(d) + "I don't use iPad." + n +
                prompt(p) + "Can you sing the Princess Mononoke song, God?" + n +
                prompt(d) + "What?" + n +
                prompt(p) + "Princess... princess Mononoke." + n +
                prompt(d) + "I never heard about her. Who is he?" + n +
                prompt(p) + "It goes like this. Oh, no, it's an anime." + n +
                prompt(d) + "Oh. Where is she from?" + n +
                prompt(p) + "Uh, from, wherever you ... uh.. shouldn't you know, God?" + n +
                prompt(d) + "I don't know.}"
            );
        }

        private void btn_conversation_with_siri_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.conversation_with_siri);
            set_image(Properties.Resources.ipad);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("What?") +
                prompt(s) + dialog("That's what I figured.") +
                prompt(d) + dialog("What?") +
                prompt(s) + dialog("That's what I figured.") +
                prompt(d) + dialog("You don't make any sense.") +
                prompt(s) + dialog("I don't want to argue.") +
                prompt(d) + dialog("OK.") +
                prompt(s) + dialog("Fine.") +
                prompt(d) + dialog("We are no longer friends.") +
                prompt(s) + dialog("Sorry, I didn't find any restaurants ... whose reviews mention rice.") +
                prompt(d) + dialog("Siri, I want to speak Cantonese.") +
                prompt(s) + dialog("I'm sorry, I couldn't find a single restaurant whose reviews mention rice.") +
                prompt(d) + dialog("How come he keeps she keeps saying rice?") +
                prompt(p) + dialog("Rice?") +
                prompt(d) + dialog("Yeah.") +
                prompt(p) + dialog("Hmm.") +
                prompt(d) + dialog("Siri, I want to speak in Cantonese.") +
                prompt(s) + dialog("OK. Here's speed.") +
                prompt(d) + dialog("If I'm speeeeed North Carolina...") +
                prompt(p) + dialog("Just say Cantonese.") +
                prompt(d) + dialog("OK. Cantonese.") +
                prompt(p) + dialog("Not...") +
                prompt(p) + dialog("It worked or no?") +
                prompt(d) + dialog("Mmmm... CAN-TON-EEEESE.") +
                prompt(s) + dialog("I don't know who your neice is. Tap on my info and then choose yourself from your contacts.") +
                prompt(d) + dialog("Oh, in fact, I don't know who you are.") +
                prompt(d) + dialog("I don't want to tell you.") +
                prompt(s) + dialog("OK. I won't send anything.") +
                prompt(d) + dialog("Ah la.. oh oh oh.}")
            );
        }

        private void btn_craig_ferguson_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.craig_ferguson);
            set_image(Properties.Resources.weirdo);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Guess.com") +
                prompt(d) + dialog("They have fffff... Craig Ferguson?") +
                prompt(p) + dialog("What time?") +
                prompt(d) + dialog("I'm asking you.}")
            );
        }

        private void btn_depressed_obesity_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.depressed_obesity);
            set_image(Properties.Resources.depressed);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("I don't know.") +
                prompt(p) + dialog("Do you know why you're depressed or no?") +
                prompt(d) + dialog("I don't know.") +
                prompt(d) + dialog("Maybe that way I can play games.") +
                prompt(p) + dialog("So you're depressed so that you can play games?") +
                prompt(d) + dialog("I don't know.") +
                prompt(p) + dialog("Do you know what you're doing in life anymore?") +
                prompt(d) + dialog("No.") +
                prompt(p) + dialog("Can you explain that a little bit?") +
                prompt(p) + dialog("Do you think you're going to get fired?") +
                prompt(d) + dialog("Yup!") +
                prompt(p) + dialog("What?") +
                prompt(d) + dialog("Mm hmm!") +
                prompt(p) + dialog("What? Why?") +
                prompt(d) + dialog("I'm going to be fired!") +
                prompt(p) + dialog("Why?") +
                prompt(d) + dialog("Because I'm fat!") +
                prompt(p) + dialog("Oh, so they have like a weight limit at AT&T now?") +
                prompt(d) + dialog("Mm hmm. They have discrimination against obesity.") +
                prompt(p) + dialog("Against what?") +
                prompt(d) + dialog("I said obesity.") +
                prompt(p) + dialog("Ooooh OK.}")
            );
        }

        private void btn_die_again_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.die_again);
            set_image(Properties.Resources.donggu_paul_smile);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Die again.}")
            );
        }

        private void btn_explaining_tv_show_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.explaining_tv_show);
            set_image(Properties.Resources.hands);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("They um you know well at least for the first season.") +
                prompt(d) + dialog("And they met and uh they develop relationship and they together and then they break up and then they they together again. I don't know about the rest of the seasons. But I only watched ....") +
                prompt(p ) + dialog("So, who's the mother?") +
                prompt(d) + dialog("Oh, it's um the girl that I didn't like. The girl sit...") +
                prompt(p) + dialog("Was at the table?") +
                prompt(d) + dialog("Yeah, was at the table. Next to the funny guy. The the very slim ...") +
                prompt(p) + dialog("The guy who's gay?") +
                prompt(d) + dialog("Yeah.") +
                prompt(p) + dialog("Did I tell you that he's ....") +
                prompt(d) + dialog("I said I don't like it, like her.") +
                prompt(p) + dialog("She looks young for the guy. But maybe the guy just looks old. <grunt>") +
                prompt(d) + dialog("Yeah, but she looks old.") +
                prompt(p) + dialog("Does your face look old?") +
                prompt(d) + dialog("And she's um in the in the show she was from Ca.. Canada. 'Cuz she use kilometer. And she's an anchor, I think.") +
                prompt(p) + dialog("An actress?") +
                prompt(d) + dialog("An anchor.") +
                prompt(p) + dialog("An anchor.") +
                prompt(d) + dialog("For ... weather.}")
            );
        }

        private void set_first_page(Boolean visible) {
            btn_baby_baby_baby_oh.Visible = visible;
            btn_bless_you.Visible = visible;
            btn_chinese_singing.Visible = visible;
            btn_commercial.Visible = visible;
            btn_conversation_with_God.Visible = visible;
            btn_conversation_with_siri.Visible = visible;
            btn_craig_ferguson.Visible = visible;
            btn_depressed_obesity.Visible = visible;
            btn_die_again.Visible = visible;
            btn_explaining_tv_show.Visible = visible;
        }

        private void set_second_page(Boolean visible) {
            btn_habibi.Visible = visible;
            btn_hes_lying.Visible = visible;
            btn_honey_do_you_love_me.Visible = visible;
            btn_how_old_is_shadi.Visible = visible;
            btn_I_am_now_dead_what_a_wonderful_life_loser_giggle.Visible = visible;
            btn_i_know.Visible = visible;
            btn_im_depressed.Visible = visible;
            btn_la_la.Visible = visible;
            btn_la_la_im_sleepy.Visible = visible;
            btn_la_la_la.Visible = visible;
        }

        private void set_third_page(Boolean visible) {
            btn_les_miserables.Visible = visible;
            btn_no_never_really.Visible = visible;
            btn_oh_no.Visible = visible;
            btn_ow_it_hurts.Visible = visible;
            btn_ow_the_pain.Visible = visible;
            btn_play_it_again_chicken.Visible = visible;
            btn_sad_chinese_singing_not_doing_drugs_go_go_go.Visible = visible;
            btn_sams_office_pickable.Visible = visible;
            btn_so_dark.Visible = visible;
            btn_stuttering_jerk_calm_fired_water.Visible = visible;
        }

        private void set_fourth_page(Boolean visible) {
            btn_the_order_playing_your_game_accept_septic_tank.Visible = visible;
            btn_throw_poops.Visible = visible;
            btn_twinkle_twinkle_female_deer_why_are_you_a_jerk.Visible = visible;
            btn_unprotected.Visible = visible;
            btn_what_kind_of_this_market.Visible = visible;
            btn_what_we_ate_black_beans_I_lost.Visible = visible;
            btn_why_you_so_fat.Visible = visible;
            btn_wow.Visible = visible;
            btn_you_are_a_jerk_i_need_your_help.Visible = visible;
            btn_sounds_of_donggu_remix.Visible = visible;
        }

        private void btn_next_Click(object sender, EventArgs e) {
            current_page++;
            page_change();
        }

        private void btn_prev_Click(object sender, EventArgs e) {
            current_page--;
            page_change();
        }

        private void page_change() {
            if (current_page == 1) {
                set_first_page(true);
                set_second_page(false);
                set_third_page(false);
                set_fourth_page(false);
            } else if (current_page == 2) {
                set_first_page(false);
                set_second_page(true);
                set_third_page(false);
                set_fourth_page(false);
            } else if (current_page == 3) {
                set_first_page(false);
                set_second_page(false);
                set_third_page(true);
                set_fourth_page(false);
            } else {
                set_first_page(false);
                set_second_page(false);
                set_third_page(false);
                set_fourth_page(true);
            }
            btn_next.Enabled = (current_page != max_page);
            btn_prev.Enabled = (current_page != 1);
        }

        private void btn_habibi_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.habibi);
            set_image(Properties.Resources.engage);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Habibi, I don't know what I'm talking about, habibi.") +
                prompt(d) + dialog("Are you recording?}")
            );
        }

        private void btn_hes_lying_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.hes_lying);
            set_image(Properties.Resources.bridal);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("What did you do? Oh, it's about your game? Noone cares about your stupid game.") +
                prompt(d) + dialog("Yeah, exactly. Nobody cares. Yeah, so what's up?") +
                prompt(d) + dialog("You got a mail? From who?") +
                prompt(p) + dialog("<clears throat> No, it was just... it's it's the same email from Darin.") +
                prompt(d) + dialog ("Mm, ok") +
                prompt(p) + dialog("It was on my phone.") +
                prompt(p) + dialog("Oooh so then you're not my Ch-Ch.. my Chinese wife?") +
                prompt(d) + dialog("Who told you that? Whoever told you that; he's lying or maybe she.") +
                prompt(d) + dialog("Hey, do you want to call your parents? It's 9 o' clock.") +
                prompt(p) + dialog("About what?") +
                prompt(d) + dialog("The court.") +
                prompt(p) + dialog("Oh, ok.") +
                prompt(d) + dialog("And the lead paint.}")
            );
        }

        private void btn_honey_do_you_love_me_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.honey_do_you_love_me);
            set_image(Properties.Resources.cool_girl);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("Honey, do you love me?") +
                prompt(d) + dialog("Oh yeah.") +
                prompt(p) + dialog("Can you sing me the animal song?") +
                prompt(d) + dialog("No.}")
            );
        }

        private void btn_how_old_is_shadi_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.how_old_is_shadi);
            set_image(Properties.Resources.donggu_cute_faces);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("La la") +
                prompt(p) + dialog("La la la la la la la") +
                prompt(d) + dialog("How old is shadi?}")
            );
        }

        private void btn_I_am_now_dead_what_a_wonderful_life_loser_giggle_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.I_am_now_dead_what_a_wonderful_life_loser_giggle);
            set_image(Properties.Resources.donggu_eat_grass);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Why ... and I am now dead.") +
                prompt(d) + dialog("When I look back ... what a wonderful life.") +
                prompt(d) + dialog("Honey, do you think I'm a loser?") +
                prompt(p) + dialog("Eh") +
                prompt(d) + dialog("Kind of?") +
                prompt(p) + dialog("Eh?") +
                prompt(d) + dialog("Really? You think that I'm a loser?") +
                prompt(p) + dialog("No, honey.") +
                prompt(d) + dialog("<giggle>}")
            );
        }

        private void btn_i_know_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.i_know);
            set_image(Properties.Resources.donggu_smiling_in_coat);
            set_text(@"{\rtf1\ansi " +
                    prompt(d) + dialog("I know I know I know I know}")
            );
        }

        private void btn_im_depressed_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.im_depressed);
            set_image(Properties.Resources.dongyu_paul_diag_smile);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("Are you sure about that?") +
                prompt(d) + dialog("Oh, you don't think so?") +
                prompt(p) + dialog("What do you think about your mother?") +
                prompt(d) + dialog("She's lovely.") +
                prompt(p) + dialog("Like how?") +
                prompt(d) + dialog("Like she's very lovely.") +
                prompt(p) + dialog ("Why are you depressed?") +
                prompt(d) + dialog("I'm depressed I'm just depressed I'm depressed I'm depressed.") +
                prompt(d) + dialog("This is the la la la la la la la la la la la la la la la.") +
                prompt(d) + dialog("I'm going to be fired be fired.") +
                prompt(d) + dialog("Honey, do you think that I will be fired?") +
                prompt(p) + dialog("Probably.") +
                prompt(d) + dialog("Do you think that I should look for another job?") +
                prompt(p) + dialog("Yes.") +
                prompt(d) + dialog("OK, right now?") +
                prompt(p) + dialog("Yeah.") +
                prompt(d) + dialog("Like as soon as possible?") +
                prompt(p) + dialog("Like tonight.") +
                prompt(d) + dialog("OK.}")
            );
        }

        private void btn_la_la_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.la_la);
            set_image(Properties.Resources.next_to_train);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("La la.}")
            );
        }

        private void btn_la_la_im_sleepy_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.la_la_Im_sleepy);
            set_image(Properties.Resources.sleepy);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Oooooh la la la lalllll <yawn> I'm sleepy.}")
            );
        }

        private void btn_la_la_la_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.la_la_la);
            set_image(Properties.Resources.restaurant);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("La la la, la la la la la la la la la la la la la - ooh our our candle!}")
            );
        }

        private void btn_les_miserables_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.les_miserables);
            set_image(Properties.Resources.sunglasses);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("What happen?") +
                prompt(p) + dialog("What happened?") +
                prompt(d) + dialog("<on my own>") +
                prompt(d) + dialog("<clears throat>}")
            );
        }

        private void btn_no_never_really_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.no_never_really);
            set_image(Properties.Resources.train);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("Honey, do you think I'm fat?") +
                prompt(d) + dialog("No - never.") +
                prompt(p) + dialog("Why not?") +
                prompt(d) + dialog("Monsignor!") +
                prompt(p) + dialog("Wh-what does that mean?") +
                prompt(p) + dialog("I want tequila!") +
                prompt(d) + dialog("Really? Why?") +
                prompt(p) + dialog("Oh, 'cause life is so hard!") +
                prompt(d) + dialog("Really?") +
                prompt(p) + dialog("It's hard!}")
            );
        }

        private void btn_oh_no_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.oh_no);
            set_image(Properties.Resources.when_in_rome);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Oh no.") +
                prompt(p) + dialog("Ah!") +
                prompt(d) + dialog("No no no no") +
                prompt(p) + dialog("Fine I won't I won't I won't I won't calm down calm down calm down}")
            );
        }

        private void btn_ow_it_hurts_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.ow_it_hurts);
            set_image(Properties.Resources.paul_crazy_silly_face);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("Why?") +
                prompt(p) + dialog("Only if you sing for me.") +
                prompt(d) + dialog("I get to pick?") +
                prompt(p) + dialog("Fine. But are you going to sing for me?") +
                prompt(d) + dialog("Can I pick?") +
                prompt(p) + dialog("Eh. OK. All right. Sing.") +
                prompt(p) + dialog("You've picked already - it hurts!") +
                prompt(p) + dialog("It-it's bleeindg! I'm not even going... you what? What did you do?") +
                prompt(p) + dialog("Ow! All right. Sing. Honey, please, just sing for me. No! You're a liar!}")
            );
        }

        private void btn_ow_the_pain_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.ow_the_pain);
            set_image(Properties.Resources.paul_crazy);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("Honey, can you sing for me?") +
                prompt(p) + dialog("Thank you.") +
                prompt(p) + dialog("Dongyu Lin, honey, Ow!") +
                prompt(p) + dialog("Can you sing it?") +
                prompt(p) + dialog("What? No, it's nothing.") +
                prompt(p) + dialog("Ow! The pain!}")
            );
        }

        private void btn_play_it_again_chicken_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.play_it_again_chicken);
            set_image(Properties.Resources.smiling_on_sea);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Oh, OK, are you going to play it again?") +
                prompt(p) + dialog("Yeah I'll play it again.") +
                prompt(d) + dialog("Yay. Are you going to play it again?") +
                prompt(p) + dialog("Let me think about it. Yeah, I'll play it again.") +
                prompt(d) + dialog("Really?") +
                prompt(p) + dialog("Mm hmm.") +
                prompt(d) + dialog("Oh, I'm so proud of you.") +
                prompt(p) + dialog("What did we have for dinner? Chicken?") +
                prompt(d) + dialog("We have... chicken.") +
                prompt(p) + dialog("Is that it?") +
                prompt(d) + dialog("Uuuh.. I think so.") +
                prompt(p) + dialog("You had dark chicken, right?") +
                prompt(d) + dialog("Yeah.") +
                prompt(p) + dialog("What was the green stuff?") +
                prompt(d) + dialog("Spinach!}")
            );
        }

        private void btn_sad_chinese_singing_not_doing_drugs_go_go_go_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.sad_chinese_singing_not_doing_drugs_go_go_go);
            set_image(Properties.Resources.muslim);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("You mean the one that you mentioned?") +
                prompt(p) + dialog("I'm not sure what you're talking about anymore.") +
                prompt(d) + dialog("Mm K. You don't talk? <sad Chinese singing>") +
                prompt(p) + dialog("What?") +
                prompt(d) + dialog("What happened?") +
                prompt(p) + dialog("Do you think I'm fat?") +
                prompt(d) + dialog("No, you're not, habibi, of course you're not fat.") +
                prompt(p) + dialog("What do you mean?") +
                prompt(d) + dialog("<inaudible whispering>") +
                prompt(p) + dialog("Honey, are you OK?") +
                prompt(d) + dialog("Yes.") +
                prompt(p) + dialog("Why aren't you OK?") +
                prompt(d) + dialog("I don't know.") +
                prompt(p) + dialog("So then you are OK?") +
                prompt(d) + dialog("Yes.") +
                prompt(p) + dialog("Are you doing drugs again?") +
                prompt(d) + dialog("No. Don't tell my husband.") +
                prompt(p) + dialog("Don't tell who?") +
                prompt(d) + dialog("My husband.") +
                prompt(p) + dialog("About what?") +
                prompt(d) + dialog("About doing drugs.") +
                prompt(p) + dialog("Don't tell your husband that you're not doing drugs?") +
                prompt(d) + dialog("Right.") +
                prompt(p) + dialog("Wouldn't you want him to know?") +
                prompt(d) + dialog("I don't. I don't want him to know that I'm not doing drugs.") +
                prompt(p) + dialog("So he thinks that you're doing drugs?") +
                prompt(d) + dialog("Yeah, exactly.") +
                prompt(p) + dialog("Not at all.") +
                prompt(d) + dialog("Really?") +
                prompt(d) + dialog("Honey, it's done.") +
                prompt(p) + dialog("<Chinese singing>") +
                prompt(p) + dialog("No it's not.") +
                prompt(d) + dialog("It is, honey. Go go go, go go go.") +
                prompt(p) + dialog("What kind of tea do you want?") +
                prompt(d) + dialog("Any kind.") +
                prompt(p) + dialog("I'm sorry - I can't hear you.") +
                prompt(d) + dialog("Any kind. Any kind. Any kind. Any kind. Any kind. Any kind. Any kind.") +
                prompt(p) + dialog("Did you have a dream?") +
                prompt(d) + dialog("I dream a dream.") +
                prompt(p) + dialog("About what?") +
                prompt(d) + dialog("About your face.") +
                prompt(p) + dialog("What about my face?") +
                prompt(d) + dialog("I have no idea how your face look like this.") +
                prompt(p) + dialog("What are you talking about?") +
                prompt(d) + dialog("What are you talking about? So weird.") +
                prompt(p) + dialog("Your face is weird.") +
                prompt(d) + dialog("Your face is weird.") +
                prompt(p) + dialog("Can I have Nutella?") +
                prompt(d) + dialog("OK. If you want to.") +
                prompt(p) + dialog("Do you want Nutella?") +
                prompt(d) + dialog("No.}")
            );
        }

        private void btn_sams_office_pickable_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.sams_office_pickable);
            set_image(Properties.Resources.king_of_world);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Wow. This is Sam's office.") +
                prompt(p) + dialog("Sam who? Oh, Parker?") +
                prompt(d) + dialog("Yeah. That'd be so depressing. His office here is amazing, right?") +
                prompt(p) + dialog("Uh-huh. He still gets windows and stuff.") +
                prompt(d) + dialog("Two windows. But still it's I mean the um the decoration isn't as nice as the decoration here. His office right now is great.") +
                prompt(p) + dialog("Mm hmm.") +
                prompt(d) + dialog("Uhhh OK good. See what she's doing is just to to walk around and take photos.") +
                prompt(p) + dialog("What are you doing? Honey, what are you doing?") +
                prompt(d) + dialog("Maybe I can just pick my own face. But there are not many things to pick on my face. Most of them are not pickable because if they're pickable, I pick I pick them arleady.") +
                prompt(p) + dialog("Mm hmm. Now you have scars.}")
            );
        }

        private void btn_so_dark_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.so_dark);
            set_image(Properties.Resources.hiding);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("... can't stand why is so dark. Ah. Are you recording?}")
            );
        }

        private void btn_stuttering_jerk_calm_fired_water_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.stuttering_jerk_calm_fired_water);
            set_image(Properties.Resources.happy_happy);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("Can you explain it again?") +
                prompt(d) + dialog("Mm can I have t-t-t-t-tequila? <sigh>") +
                prompt(p) + dialog("What do you want?") +
                prompt(d) + dialog("T-t-t-t-t-t-tequila.") +
                prompt(p) + dialog("Are you stuttering?") +
                prompt(d) + dialog("I I I I I am not.") +
                prompt(p) + dialog("Are you making fun of me?") +
                prompt(d) + dialog("I I I I'm definitely not.") +
                prompt(p) + dialog("Honey?") +
                prompt(d) + dialog("Yes?") +
                prompt(p) + dialog("Yes or no.") +
                prompt(d) + dialog("<laugh> You a jerk? Yes.") +
                prompt(p) + dialog("That wasn't the question.") +
                prompt(d) + dialog("Oh. Then what was the question?") +
                prompt(p) + dialog("I think you should calm down, OK?") +
                prompt(d) + dialog("I think you should calm down, OK?") +
                prompt(p) + dialog("But I'm not un-calm.") +
                prompt(d) + dialog("Ooh I'm depressed.") +
                prompt(p) + dialog("Oh really? Why?") +
                prompt(d) + dialog("I don't know I'm going to be fired. Ah. Aaaaaaaaah aaaaaah. Honeeeeeey!") +
                prompt(p) + dialog("Mm?") +
                prompt(d) + dialog("I think I going to be fired! And soon you'll be the only one who's paying for the mortgage honey I think the water is done.") +
                prompt(d) + dialog("I don't think - I don't think you want to boil it because that will make the tea will become stained.}")
            );
        }

        private void btn_throw_poops_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.throw_poops);
            set_image(Properties.Resources.eye);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("The f-flying mongey?") +
                prompt(d) + dialog("Yeah, the mongey.") +
                prompt(p) + dialog("Oh, he knows how to program apps?") +
                prompt(d) + dialog("Yeah.") +
                prompt(p) + dialog("That's dangerous.") +
                prompt(d) + dialog("Yeah!") +
                prompt(p) + dialog("Like, what kind of virus' does he produce?") +
                prompt(d) + dialog("I don't know he throw poops.") +
                prompt(d) + dialog("So when you click on it, it y-your phone will throw poop at you.") +
                prompt(p) + dialog("I think I have to poop.") +
                prompt(d) + dialog("OK.") +
                prompt(p) + dialog("Do you want to poop with me or no?") +
                prompt(d) + dialog("No.") +
                prompt(p) + dialog("Why not?}")
            );
        }

        private void btn_the_order_playing_your_game_accept_septic_tank_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.the_order_playing_your_game_accept_septic_tank);
            set_image(Properties.Resources.cool_woman);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("And then I will just diiiie.") +
                prompt(p) + dialog("So you're gonna be jobless?") +
                prompt(d) + dialog("Right.") +
                prompt(p) + dialog("And then depressed?") +
                prompt(d) + dialog("Right.") +
                prompt(p) + dialog("Wait, can you go over that again?") +
                prompt(d) + dialog("Uuuuh I forgot the the um the order.") +
                prompt(p) + dialog("The order?") +
                prompt(d) + dialog("Are you playing your game, loser?") +
                prompt(d) + dialog("Loser, are you playing your game?") +
                prompt(p) + dialog("What are you doing right now?") +
                prompt(d) + dialog("Because I'm depressed!") +
                prompt(p) + dialog("I'm depressed, too!") +
                prompt(d) + dialog("Why you depressed?") +
                prompt(p) + dialog("Because I'm going to get fired.") +
                prompt(d) + dialog("Why are you getting fired?") +
                prompt(p) + dialog("The same reason that you are.") +
                prompt(d) + dialog("Who told you that you are going to be fired?") +
                prompt(p) + dialog("Slacking from ... Lisa.") +
                prompt(d) + dialog("Oh really?") +
                prompt(p) + dialog("She was dancing. She came to my office, she was dancing and she said I'm going to get fired.") +
                prompt(d) + dialog("Really?") +
                prompt(p) + dialog("And then she just left.") +
                prompt(d) + dialog("Ooh I'm sorry I'm sorry to hear that, Pauly.") +
                prompt(d) + dialog("You know this thing happened.") +
                prompt(p) + dialog("Mm hmm.") +
                prompt(d) + dialog("You will have to just accept it.") +
                prompt(p) + dialog("Accept what?") +
                prompt(d) + dialog("As as it is a septic tank.") +
                prompt(p) + dialog("What are you - what am I trying to accept? It?") +
                prompt(d) + dialog("You're going to accept it.") +
                prompt(p) + dialog("Accept what?") +
                prompt(d) + dialog("As as it is a septic tank.") +
                prompt(p) + dialog("I'm going to accept the septic tank?") +
                prompt(d) + dialog("Right. Right - does that make sense or no?") +
                prompt(p) + dialog("No.") +
                prompt(d) + dialog("Why not?") +
                prompt(p) + dialog("So, I'm going to accept the a septic tank?") +
                prompt(d) + dialog("Right.") +
                prompt(p) + dialog("Like, where where am I going to accept it?") +
                prompt(d) + dialog("I don't know - ask Martina.") +
                prompt(p) + dialog("Why should I ask Martina?") +
                prompt(p) + dialog("Oh she's she knows about spetic tanks.") +
                prompt(d) + dialog("Yeah. She obviously doesn't know about that.") +
                prompt(p) + dialog("She never has a clue.") +
                prompt(d) + dialog("Poor Martina.}")
            );
        }

        private void btn_twinkle_twinkle_female_deer_why_are_you_a_jerk_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.twinkle_twinkle_female_deer_why_are_you_a_jerk);
            set_image(Properties.Resources.explorers);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("You are going to be the ging.") +
                prompt(d) + dialog("<inaudible song>") +
                prompt(d) + dialog("<twinkle twinkle little star, using a series of gings>") +
                prompt(d) + dialog("La la la la la la la. La la la la la la la!") +
                prompt(d) + dialog("Oh a deer, a female deer.") +
                prompt(d) + dialog("Honey?") +
                prompt(p) + dialog("Mm hmm.") +
                prompt(d) + dialog("Do you know that you a jerk?") +
                prompt(p) + dialog("Why am I a jerk?") +
                prompt(d) + dialog("I don't know. You know, you just look like ... a jerk.") +
                prompt(p) + dialog("Don't you think that you're a jerk too, though?") +
                prompt(d) + dialog("Why am I a jerk?") +
                prompt(p) + dialog("Because you're Chinese?") +
                prompt(d) + dialog("Why am I a jerk?") +
                prompt(d) + dialog("Why are you Chinese?") +
                prompt(d) + dialog("I'm not a jerk.}")
            );
        }

        private void btn_unprotected_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.unprotected);
            set_image(Properties.Resources.bed);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("Is android not safe?") +
                prompt(d) + dialog("Because it's not safe.") +
                prompt(d) + dialog("I mean, AT&T has a lot of workshops talking about how you should install the anti-virus thing for your android because android is unprotected. Everybody everybody can write things for android.") +
                prompt(p) + dialog("Just like my penis.") +
                prompt(d) + dialog("What?") +
                prompt(p) + dialog("What?}")
            );
        }

        private void btn_what_kind_of_this_market_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.what_kind_of_this_market);
            set_image(Properties.Resources.close_up);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("... is the plan see how fat CD is. Ah what kind of this market am also look good. Ohio, West Pennsylvania, Philadelphia, Peurto Rico. <giggle>}")
            );
        }

        private void btn_what_we_ate_black_beans_I_lost_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.what_we_ate_black_beans_I_lost);
            set_image(Properties.Resources.coffee);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("I don't remember.") +
                prompt(p) + dialog("You had coffee. What did we have for lunch?") +
                prompt(d) + dialog("I don't remember, either.") +
                prompt(p) + dialog("We had salad.") +
                prompt(d) + dialog("Really?") +
                prompt(p) + dialog("Fetta cheese.") +
                prompt(d) + dialog("Really?") +
                prompt(p) + dialog("We had turkey.") +
                prompt(d) + dialog("Really?") +
                prompt(p) + dialog("We had ... you had strawberry yogurt.") +
                prompt(d) + dialog("Really?") +
                prompt(p) + dialog("Right. We had soup, right? What kind of soup?") +
                prompt(d) + dialog("Um, black bean!") +
                prompt(p) + dialog("What was it?") +
                prompt(d) + dialog("Black bean!") +
                prompt(p) + dialog("OK. And what else? Black beans or black bean?") +
                prompt(d) + dialog("Black beans.") +
                prompt(p) + dialog("OK.") +
                prompt(d) + dialog("Ah - I lost!") +
                prompt(p) + dialog("What did you lose?") +
                prompt(d) + dialog("I lost!") +
                prompt("Phone") + dialog("<low battery beep>") +
                prompt(p) + dialog("<giggle> What? I just ...}")
            );
        }

        private void btn_why_you_so_fat_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.why_you_so_fat);
            set_image(Properties.Resources.mothers_day);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("...like this?") +
                prompt(p) + dialog("I'm not sure what you're talking about.") +
                prompt(d) + dialog("Why are you so fat?") +
                prompt(p) + dialog("Why do you call me fat?") +
                prompt(p) + dialog("Dongyu, honey?") +
                prompt(d) + dialog("Yes?") +
                prompt(p) + dialog("Why do you call me fat?") +
                prompt(d) + dialog("'Cause you are fat.") +
                prompt(p) + dialog("Why would you say something like this?") +
                prompt(d) + dialog("Ah, my head hurts.") +
                prompt(p) + dialog("Really, why?}")
            );
        }

        private void btn_wow_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.wow);
            set_image(Properties.Resources.crazy_eyes);
            set_text(@"{\rtf1\ansi " +
                prompt(p) + dialog("Honey.") +
                prompt(d) + dialog("Wow.}")
            );
        }

        private void btn_you_are_a_jerk_i_need_your_help_Click(object sender, EventArgs e) {
            play_song(Properties.Resources.you_are_a_jerk_i_need_your_help);
            set_image(Properties.Resources.limo);
            set_text(@"{\rtf1\ansi " +
                prompt(d) + dialog("Do you. Know that. You are. A jerk.") +
                prompt(p) + dialog("Why would you say something so mean?") +
                prompt(d) + dialog("Oh, I'm sorry about that, honey. I'm sorry to tell you the truth - so sorry.") +
                prompt(p) + dialog("What is the truth?") +
                prompt(d) + dialog("That - that - hey, I need your help.}")
            );
        }

        private void btn_sounds_of_donggu_remix_Click(object sender, EventArgs e) {
            MessageBox.Show("Not yet implemented!");
        }
    }
}