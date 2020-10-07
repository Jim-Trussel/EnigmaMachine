using System.Collections.Generic;
using System.Linq;
using Enigma;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        private RotorGroup3 _rotorGroup;


        [Fact]
        public void Test1()
        {
            _rotorGroup = new RotorGroup3(
                new Rotor(RotorType.I),
                new Rotor(RotorType.II),
                new Rotor(RotorType.III),
                new Reflector(ReflectorType.B)
            );

            _rotorGroup.RotorPositions = new[]
            {
                'A',
                'A',
                'A'
            };

            _rotorGroup.RingSettings = new[]
            {
                'A',
                'A',
                'A'
            };

            var charsExpected = new List<char>();
            charsExpected.Add('B');
            charsExpected.Add('D');
            charsExpected.Add('Z');
            charsExpected.Add('G');
            charsExpected.Add('O');
            charsExpected.Add('W');
            charsExpected.Add('C');
            charsExpected.Add('X');


            var chars = new List<char>();
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));

            Assert.Equal(charsExpected, chars);
        }


        [Fact]
        public void Test2()
        {
            _rotorGroup = new RotorGroup3(
                new Rotor(RotorType.I),
                new Rotor(RotorType.II),
                new Rotor(RotorType.III),
                new Reflector(ReflectorType.B)
            );

            _rotorGroup.RotorPositions = new[]
            {
                'A',
                'A',
                'A'
            };

            _rotorGroup.RingSettings = new[]
            {
                'B',
                'B',
                'B'
            };

            var charsExpected = new List<char>();
            charsExpected.Add('E');
            charsExpected.Add('W');
            charsExpected.Add('T');
            charsExpected.Add('Y');
            charsExpected.Add('X');

            var chars = new List<char>();
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));
            chars.Add(_rotorGroup.GetOutput('A'));

            Assert.Equal(charsExpected, chars);
        }


        [Fact]
        public void Test3()
        {
            var settings = new MachineSettings
            {
                Plugs = new char[0],
                Reflector = ReflectorType.B,
                RingPositions = new[]
                {
                    'A',
                    'A',
                    'A'
                },
                RotorGroupType = RotorGroupType.Rotor3,
                RotorPositions = new[]
                {
                    'A',
                    'A',
                    'A'
                },
                Rotors = new[]
                {
                    RotorType.I,
                    RotorType.II,
                    RotorType.III
                }
            };
            var enigmaMachine = new Machine(settings);

            var charsExpected = new List<char>();
            charsExpected.Add('B');
            charsExpected.Add('D');
            charsExpected.Add('Z');
            charsExpected.Add('G');
            charsExpected.Add('O');
            charsExpected.Add('W');
            charsExpected.Add('C');
            charsExpected.Add('X');

            var chars = new List<char>();
            chars.Add(enigmaMachine.PressKey('A'));
            chars.Add(enigmaMachine.PressKey('A'));
            chars.Add(enigmaMachine.PressKey('A'));
            chars.Add(enigmaMachine.PressKey('A'));
            chars.Add(enigmaMachine.PressKey('A'));
            chars.Add(enigmaMachine.PressKey('A'));
            chars.Add(enigmaMachine.PressKey('A'));
            chars.Add(enigmaMachine.PressKey('A'));

            Assert.Equal(charsExpected, chars);
        }

        [Fact]
        public void Test5()
        {
            _rotorGroup = new RotorGroup3(
                new Rotor(RotorType.I),
                new Rotor(RotorType.II),
                new Rotor(RotorType.III),
                new Reflector(ReflectorType.B)
            );

            _rotorGroup.RotorPositions = new[]
            {
                'A',
                'D',
                'U'
            };

            _rotorGroup.RingSettings = new[]
            {
                'A',
                'A',
                'A'
            };

            _rotorGroup.GetOutput('A');

            var p = _rotorGroup.RotorPositions;

            _rotorGroup.GetOutput('A');

            p = _rotorGroup.RotorPositions;

            _rotorGroup.GetOutput('A');

            p = _rotorGroup.RotorPositions;

            _rotorGroup.GetOutput('A');

            p = _rotorGroup.RotorPositions;

            //  _rotorGroup.GetOutput('A');

            //   p = _rotorGroup.RotorPositions;

            Assert.Equal("BFY".ToCharArray(), p);
        }


        [Fact]
        public void TestBigText()
        {
            var settings = new MachineSettings
            {
                Plugs = new char[0],
                Reflector = ReflectorType.B,
                RingPositions = new[]
                {
                    'A',
                    'A',
                    'A'
                },
                RotorGroupType = RotorGroupType.Rotor3,
                RotorPositions = new[]
                {
                    'A',
                    'A',
                    'A'
                },
                Rotors = new[]
                {
                    RotorType.I,
                    RotorType.II,
                    RotorType.III
                }
            };
            var enigmaMachine = new Machine(settings);

            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();

            var input = new List<char>();

            var myString = @"


The Enigma machine is an encryption device developed and used in the early- to mid-20th century to protect commercial, diplomatic and military communication. It was employed extensively by Nazi Germany during World War II, in all branches of the German military.

Enigma has an electromechanical rotor mechanism that scrambles the 26 letters of the alphabet. In typical use, one person enters text on the Enigma's keyboard and another person writes down which of 26 lights above the keyboard lights up at each key press. If plain text is entered, the lit-up letters are the encoded ciphertext. Entering ciphertext transforms it back into readable plaintext. The rotor mechanism changes the electrical connections between the keys and the lights with each keypress. The security of the system depends on a set of machine settings that were generally changed daily during the war, based on secret key lists distributed in advance, and on other settings that were changed for each message. The receiving station has to know and use the exact settings employed by the transmitting station to successfully decrypt a message.

While Germany introduced a series of improvements to Enigma over the years, and these hampered decryption efforts to varying degrees, they did not ultimately prevent Britain and its allies from exploiting Enigma-encoded messages as a major source of intelligence during the war. Many commentators say the flow of communications intelligence from Ultra's decryption of Enigma, Lorenz and other ciphers shortened the war significantly and may even have altered its outcome.[1]



";
            var sOut1 = @"
opcwc lznlv kkgqo nynpz yvwgm qgvjy wycuu zcqyt yftkm neoxx zgfcc rctht rlgzp qvgyr zzrwo bwayz tkhue urhdu oshwo ajcvn ybfmb jqlkl hbffd jizff ttaib lydxo sgvkr uyxhb yviyq cfrfo gohtu qejfy ffjbo qyihv yiieq gmycy rllbo xqldg ctvlp qdurs bzevn byqre ccqic plxib ojftf jftks umfnq grsym xgdse pxwsa gpzck zkosq eapgv rbhec ppjyw umktk pbbxi mguyt qariz eiwpu bztwh pigxh nazkz bqles flkmj htndv mwaiq qmdiz ipett kgirz bjydj wxigc xuiva xfnsk zfozt gsgor wflot uuxxy rxenl tdnnn kiuhr tovth evexp lylkc rtoro ldqxs qkwhi pbhys ysrhv pyfzb bfmtl voxba gwjal bxgvs epfyv hymxx eskkl dtclq gssml ovkct iwhpf xevuf hmtcx nzlhl eprdh tdhiv lrlrp vwebr oxxsf wwqfi lrlte zikch bbugz flnqb znkuf eakwe josxb kwgpn ahnoc heiac qrxfs fdaee zmbew cooui strxb uqhwz ilboc ifake zvaww ffwdy coybi kteue qudwk pzpyc batqe fbpkr jkmnd tbzby txeqd hctmu gwods fddvb ecfkn pglev ttrvo yfueq nhvhf jniem fjqji hzzyk lhsqu hkeiz pxybr qfbgg cwtlq ckwzq bziyi zdxaj bzkfz tyuze idfmp kduzn zjffg wkxkg zlqre cutcs ybyfa iyinb hrtnp datqd fywaz xoumw pgara gfoyj izkli xgvmh pzqvg ledod hrtaw sbtdj hjecl xarrr bjdry owedl hzehx iqhom butcv zosfg qzrdb kmyki hajhp vgiqa sgfai pmtro qojun jtawq mpriu mavfv mvozt slqaq lgeol zpdqu yrrqr okpkl mutjp rwztl okqzd njkal gfhnf ytzbw caprv wgyis vqfgk qnrir xgpbg zdmuo jnhgs bqiyk rdqgv vyzjf tvout uwzyk ebmbh hovrx oqgae zftca anhss ibglz bnzxa dbyqn chmpv lnexm uetdz hngti rrzmd mztpn iqnms uubbr dzyfh njltp nruvp vwtbb edobu vjlrh jpjqh txwlf nqzvp pcbhg bsbix ekuxn iakhf opryz xksam wpcey zixvz eooxt gwyvs keafi kyxno gnqri nicsi byntg
";
            var t = "";
            foreach (var c in myString.ToUpper().ToCharArray())
            {
                if (alphabet.Contains(c))
                {
                    t += c;
                    input.Add(c);
                }
            }


            var charsExpected = new List<char>();
            var tt = "";
            foreach (var c in sOut1.ToUpper().ToCharArray())
            {
                if (alphabet.Contains(c))
                {
                    tt += c;
                    charsExpected.Add(c);
                }
            }


            var index = 0;
            var chars = new List<char>();
            foreach (var i in input)
            {
                var beforePos = enigmaMachine.GetRotorPosition();
                chars.Add(enigmaMachine.PressKey(i));


                var pos = enigmaMachine.GetRotorPosition();

                var t1 = chars[index];
                var t2 = charsExpected[index];
                if (chars[index] != charsExpected[index])
                {
                    var a = 1;
                }


                index++;
            }


            //charsExpected.Add('B');
            //charsExpected.Add('D');
            //charsExpected.Add('Z');
            //charsExpected.Add('G');
            //charsExpected.Add('O');
            //charsExpected.Add('W');
            //charsExpected.Add('C');
            //charsExpected.Add('X');


            //chars.Add(enigmaMachine.PressKey('A'));
            //chars.Add(enigmaMachine.PressKey('A'));
            //chars.Add(enigmaMachine.PressKey('A'));
            //chars.Add(enigmaMachine.PressKey('A'));
            //chars.Add(enigmaMachine.PressKey('A'));
            //chars.Add(enigmaMachine.PressKey('A'));
            //chars.Add(enigmaMachine.PressKey('A'));
            //chars.Add(enigmaMachine.PressKey('A'));

            var o1 = string.Join("", charsExpected.ToArray());
            var o2 = string.Join("", chars.ToArray());


            Assert.Equal(charsExpected, chars);
        }
    }
}
